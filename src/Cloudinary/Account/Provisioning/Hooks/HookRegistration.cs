namespace Cloudinary.Account.Provisioning.Hooks;

public static class HookRegistration
{
    public static void InitHooks(IHooks hooks)
    {
        var config = new AccountConfig();
        var accountHook = new CloudinaryAccountHook(config);

        hooks.RegisterSDKInitHook(accountHook);
        hooks.RegisterBeforeRequestHook(accountHook);
        hooks.RegisterSDKInitHook(new UserAgentHook());
    }
}
