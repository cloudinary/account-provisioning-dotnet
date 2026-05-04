using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Cloudinary.Account.Provisioning.Models.Components;

namespace Cloudinary.Account.Provisioning.Hooks;

/// <summary>
/// Populates account_id from CLOUDINARY_ACCOUNT_URL on init and attaches
/// Basic auth (provisioning_api_key:provisioning_api_secret) to every request.
/// </summary>
internal class CloudinaryAccountHook : ISDKInitHook, IBeforeRequestHook
{
    private readonly AccountConfig _config;

    public CloudinaryAccountHook(AccountConfig config)
    {
        _config = config;
    }

    public SDKConfig SDKInit(SDKConfig config)
    {
        if (!string.IsNullOrEmpty(_config.AccountId) && string.IsNullOrEmpty(config.AccountId))
        {
            config.AccountId = _config.AccountId;
        }

        if (config.SecuritySource == null
            && !string.IsNullOrEmpty(_config.ProvisioningApiKey)
            && !string.IsNullOrEmpty(_config.ProvisioningApiSecret))
        {
            var key = _config.ProvisioningApiKey;
            var secret = _config.ProvisioningApiSecret;
            config.SecuritySource = () => new Security
            {
                ProvisioningApiKey = key,
                ProvisioningApiSecret = secret
            };
        }

        return config;
    }

    public Task<HttpRequestMessage> BeforeRequestAsync(BeforeRequestContext hookCtx, HttpRequestMessage request)
    {
        var key = _config.ProvisioningApiKey;
        var secret = _config.ProvisioningApiSecret;

        var securityVal = hookCtx.SecuritySource?.Invoke();
        if (securityVal is Security sec)
        {
            if (!string.IsNullOrEmpty(sec.ProvisioningApiKey))
                key = sec.ProvisioningApiKey;
            if (!string.IsNullOrEmpty(sec.ProvisioningApiSecret))
                secret = sec.ProvisioningApiSecret;
        }

        if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(secret))
        {
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{key}:{secret}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }

        return Task.FromResult(request);
    }
}
