using System;
using System.Runtime.InteropServices;

namespace Cloudinary.Account.Provisioning.Hooks;

/// <summary>
/// Replaces the default Speakeasy user-agent with a Cloudinary-branded one.
/// Format: Cloudinary/AccountProvisioning DotNet/{sdkVersion} Gen/{genVersion} Schema/{schemaVersion} ({runtime}; {os})
/// </summary>
internal class UserAgentHook : ISDKInitHook
{
    public SDKConfig SDKInit(SDKConfig config)
    {
        var original = config.UserAgent;
        if (string.IsNullOrEmpty(original) || !original.StartsWith("speakeasy-sdk/"))
        {
            return config;
        }

        var parts = original.Split(' ', 5);
        if (parts.Length < 5)
        {
            return config;
        }

        var sdkVersion = parts[1];
        var genVersion = parts[2];
        var schemaVersion = parts[3];
        var runtime = RuntimeInformation.FrameworkDescription;
        var os = RuntimeInformation.OSDescription;

        config.UserAgent = $"Cloudinary/AccountProvisioning DotNet/{sdkVersion} Gen/{genVersion} Schema/{schemaVersion} ({runtime}; {os})";
        return config;
    }
}
