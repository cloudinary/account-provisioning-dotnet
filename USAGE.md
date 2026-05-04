<!-- Start SDK Example Usage [usage] -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

GetProductEnvironmentsRequest req = new GetProductEnvironmentsRequest() {
    Enabled = true,
    Prefix = "product",
};

var res = await sdk.ProductEnvironments.ListAsync(req);

// handle response
```
<!-- End SDK Example Usage [usage] -->