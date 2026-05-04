using System;

namespace Cloudinary.Account.Provisioning.Hooks;

internal class AccountConfig
{
    public string AccountId { get; }
    public string ProvisioningApiKey { get; }
    public string ProvisioningApiSecret { get; }

    public AccountConfig()
    {
        var accountId = "";
        var apiKey = "";
        var apiSecret = "";

        var accountUrl = Environment.GetEnvironmentVariable("CLOUDINARY_ACCOUNT_URL");
        if (!string.IsNullOrEmpty(accountUrl))
        {
            LoadFromUrl(accountUrl, ref accountId, ref apiKey, ref apiSecret);
        }

        var v = Environment.GetEnvironmentVariable("CLOUDINARY_ACCOUNT_ID");
        if (!string.IsNullOrEmpty(v)) accountId = v;

        v = Environment.GetEnvironmentVariable("CLOUDINARY_PROVISIONING_API_KEY");
        if (!string.IsNullOrEmpty(v)) apiKey = v;

        v = Environment.GetEnvironmentVariable("CLOUDINARY_PROVISIONING_API_SECRET");
        if (!string.IsNullOrEmpty(v)) apiSecret = v;

        AccountId = accountId;
        ProvisioningApiKey = apiKey;
        ProvisioningApiSecret = apiSecret;
    }

    private static void LoadFromUrl(string rawUrl, ref string accountId, ref string apiKey, ref string apiSecret)
    {
        var uri = new Uri(rawUrl);
        if (uri.Scheme != "account")
        {
            throw new ArgumentException($"Invalid CLOUDINARY_ACCOUNT_URL scheme '{uri.Scheme}', expected 'account://'");
        }

        accountId = uri.Host;
        var userInfo = uri.UserInfo;
        if (!string.IsNullOrEmpty(userInfo))
        {
            var colonIdx = userInfo.IndexOf(':');
            if (colonIdx >= 0)
            {
                apiKey = Uri.UnescapeDataString(userInfo[..colonIdx]);
                apiSecret = Uri.UnescapeDataString(userInfo[(colonIdx + 1)..]);
            }
            else
            {
                apiKey = Uri.UnescapeDataString(userInfo);
            }
        }
    }
}
