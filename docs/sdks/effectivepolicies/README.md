# EffectivePolicies

## Overview

### Available Operations

* [List](#list) - Get effective policies

## List

Retrieve all roles (along with their system permission policies) associated with principals, and all custom permission policies directly added to principals, all within a specified scope.

Optionally specify a principal to only include roles and policies associated with that principal.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getEffectivePolicies" method="get" path="/v2/accounts/{account_id}/permissions/policies/effective" example="EffectivePoliciesExample" -->
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

GetEffectivePoliciesRequest req = new GetEffectivePoliciesRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    PrincipalType = PrincipalTypeEnum.User,
};

var res = await sdk.EffectivePolicies.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [GetEffectivePoliciesRequest](../../Models/Requests/GetEffectivePoliciesRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[EffectivePoliciesResponse](../../Models/Components/EffectivePoliciesResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 404                                                     | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |