# Public

## Overview

View shared Permissions system utilities, including the system roles and policies catalog, Cedar policy validation, and the Cedar schema. These endpoints are publicly accessible and don't require authentication.


### Available Operations

* [GetCatalog](#getcatalog) - Get system roles and policies catalog
* [ValidatePolicy](#validatepolicy) - Validate a Cedar policy
* [GetSchema](#getschema) - Get Cedar schema

## GetCatalog

Retrieves the catalog of predefined system roles and their associated policies.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSystemRolesAndPoliciesCatalog" method="get" path="/v2/accounts/permissions/public/catalog" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(security: new Security() {
    ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
    ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
});

var res = await sdk.Public.GetCatalogAsync();

// handle response
```

### Response

**[SystemRolesAndPoliciesCatalogResponse](../../Models/Components/SystemRolesAndPoliciesCatalogResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.APIException | 4XX, 5XX                                                   | \*/\*                                                      |

## ValidatePolicy

Validate a Cedar policy

### Example Usage

<!-- UsageSnippet language="csharp" operationID="validateCedarPolicy" method="post" path="/v2/accounts/permissions/public/validate" example="ValidateCedarPolicyResponseExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(security: new Security() {
    ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
    ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
});

ValidateCedarPolicyRequest req = new ValidateCedarPolicyRequest() {
    Policy = "permit(principal == Cloudinary::APIKy::\"1234\", action == Cloudinary::Action::\"read\", resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\"asdfjkl12347890\")} ;",
};

var res = await sdk.Public.ValidatePolicyAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [ValidateCedarPolicyRequest](../../Models/Components/ValidateCedarPolicyRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[ValidateCedarPolicyResponse](../../Models/Components/ValidateCedarPolicyResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.APIException | 4XX, 5XX                                                   | \*/\*                                                      |

## GetSchema

Get Cedar schema

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCedarSchema" method="get" path="/v2/accounts/permissions/public/schema" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(security: new Security() {
    ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
    ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
});

var res = await sdk.Public.GetSchemaAsync();

// handle response
```

### Response

**[CedarSchemaResponse](../../Models/Components/CedarSchemaResponse.md)**

### Errors

| Error Type                                                 | Status Code                                                | Content Type                                               |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.APIException | 4XX, 5XX                                                   | \*/\*                                                      |