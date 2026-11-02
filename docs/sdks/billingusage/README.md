# BillingUsage

## Overview

### Available Operations

* [Get](#get) - Get billing usage information

## Get

Retrieve billing usage metrics for your account and product environments, 
including storage, bandwidth, impressions, and transformations.

If `year` is provided:
  - **Annual subscription**: Returns the single annual usage cycle that began in the specified year (if any).
  - **Monthly subscription**: Returns all monthly usage cycles that began in the specified year.

If `year` is not provided:
  - Returns usage for the year in which the current active subscription period began.
  - If no active subscription exists, an empty list is returned.

**Note**: Usage metrics are updated daily, so calling this endpoint once per day gives you the latest data.


### Example Usage: AdvancedExtraPAYG

<!-- UsageSnippet language="csharp" operationID="getBillingUsage" method="get" path="/v1_1/provisioning/accounts/{account_id}/billing_usage" example="AdvancedExtraPAYG" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.BillingUsage.GetAsync(year: 2024);

// handle response
```
### Example Usage: AdvancedPAYG

<!-- UsageSnippet language="csharp" operationID="getBillingUsage" method="get" path="/v1_1/provisioning/accounts/{account_id}/billing_usage" example="AdvancedPAYG" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.BillingUsage.GetAsync(year: 2024);

// handle response
```
### Example Usage: MultiPlan

<!-- UsageSnippet language="csharp" operationID="getBillingUsage" method="get" path="/v1_1/provisioning/accounts/{account_id}/billing_usage" example="MultiPlan" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.BillingUsage.GetAsync(year: 2024);

// handle response
```
### Example Usage: ProPAYG

<!-- UsageSnippet language="csharp" operationID="getBillingUsage" method="get" path="/v1_1/provisioning/accounts/{account_id}/billing_usage" example="ProPAYG" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.BillingUsage.GetAsync(year: 2024);

// handle response
```
### Example Usage: ProPAYGPlus

<!-- UsageSnippet language="csharp" operationID="getBillingUsage" method="get" path="/v1_1/provisioning/accounts/{account_id}/billing_usage" example="ProPAYGPlus" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.BillingUsage.GetAsync(year: 2024);

// handle response
```

### Parameters

| Parameter                                                                                  | Type                                                                                       | Required                                                                                   | Description                                                                                | Example                                                                                    |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `AccountId`                                                                                | *string*                                                                                   | :heavy_minus_sign:                                                                         | Account ID                                                                                 |                                                                                            |
| `Year`                                                                                     | *int*                                                                                      | :heavy_minus_sign:                                                                         | The year to retrieve billing usage for. Behavior depends on subscription type (see above). | 2024                                                                                       |
| `IncludeProdenvBreakdown`                                                                  | *bool*                                                                                     | :heavy_minus_sign:                                                                         | Whether to include usage details by product environment. **Default**: false.<br/>          |                                                                                            |

### Response

**[List<BillingUsageResponse>](../../Models/.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 429                                     | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |