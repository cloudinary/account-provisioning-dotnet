# SystemPolicies

## Overview

### Available Operations

* [List](#list) - Get system policies

## List

Retrieve all system-defined permission policies. Optionally filter the results by `scope_type` (account or product environment) and/or `permission_type` (global or content-specific).

**Note:** If `scope_type` isn't specified as `prodenv`, the account-level policies will be returned.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSystemPolicies" method="get" path="/v2/accounts/{account_id}/permissions/policies/system" example="SystemPoliciesExample" -->
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

var res = await sdk.SystemPolicies.ListAsync(
    permissionType: PermissionTypeEnum.Global,
    scopeType: ScopeTypeEnum.Prodenv
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                  | Type                                                                                                                                                                                                                                                                                       | Required                                                                                                                                                                                                                                                                                   | Description                                                                                                                                                                                                                                                                                | Example                                                                                                                                                                                                                                                                                    |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `AccountId`                                                                                                                                                                                                                                                                                | *string*                                                                                                                                                                                                                                                                                   | :heavy_minus_sign:                                                                                                                                                                                                                                                                         | Account ID                                                                                                                                                                                                                                                                                 |                                                                                                                                                                                                                                                                                            |
| `PermissionType`                                                                                                                                                                                                                                                                           | [PermissionTypeEnum](../../Models/Components/PermissionTypeEnum.md)                                                                                                                                                                                                                        | :heavy_minus_sign:                                                                                                                                                                                                                                                                         | Specifies whether to retrieve roles whose permissions apply globally across all contexts within the scope (i.e., security settings for the account, or all folders in a product environment), or specifically to designated content instances (i.e., folder with external ID "fg3841spr"). | global                                                                                                                                                                                                                                                                                     |
| `ScopeType`                                                                                                                                                                                                                                                                                | [ScopeTypeEnum](../../Models/Components/ScopeTypeEnum.md)                                                                                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                                                                                                                                         | Specifies the level for retrieving policies or roles, either at the account level or within product environments.                                                                                                                                                                          | prodenv                                                                                                                                                                                                                                                                                    |

### Response

**[SystemPoliciesResponse](../../Models/Components/SystemPoliciesResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403                                                               | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |