# Principals

## Overview

View roles associated with a specified principal, and add or remove a role associated with a principal.


### Available Operations

* [ListRoles](#listroles) - Get a principal's roles
* [UpdateRoles](#updateroles) - Assign roles to a principal
* [Inspect](#inspect) - Inspect
* [InspectMultiple](#inspectmultiple) - Inspect multiple

## ListRoles

Retrieve all roles associated with a specific principal.

### Example Usage: GetPrincipalRolesExample

<!-- UsageSnippet language="csharp" operationID="getPrincipalRoles" method="get" path="/v2/accounts/{account_id}/permissions/principal_roles" example="GetPrincipalRolesExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

GetPrincipalRolesRequest req = new GetPrincipalRolesRequest() {
    PrincipalType = PrincipalTypeEnum.User,
    PrincipalId = "<id>",
    PermissionType = PermissionTypeEnum.Global,
    ManagementType = ManagementTypeEnum.System,
    ScopeType = ScopeTypeEnum.Prodenv,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Principals.ListRolesAsync(req);

// handle response
```
### Example Usage: GetPrincipalRolesWithParamKeyValueExample

<!-- UsageSnippet language="csharp" operationID="getPrincipalRoles" method="get" path="/v2/accounts/{account_id}/permissions/principal_roles" example="GetPrincipalRolesWithParamKeyValueExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

GetPrincipalRolesRequest req = new GetPrincipalRolesRequest() {
    PrincipalType = PrincipalTypeEnum.User,
    PrincipalId = "<id>",
    PermissionType = PermissionTypeEnum.Global,
    ManagementType = ManagementTypeEnum.System,
    ScopeType = ScopeTypeEnum.Prodenv,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Principals.ListRolesAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [GetPrincipalRolesRequest](../../Models/Requests/GetPrincipalRolesRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[PrincipalRolesResponse](../../Models/Components/PrincipalRolesResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## UpdateRoles

Add or remove roles associated with a principal.

### Example Usage: InvalidOperationFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="updatePrincipalRoles" method="put" path="/v2/accounts/{account_id}/permissions/principal_roles" example="InvalidOperationFieldErrorExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

await sdk.Principals.UpdateRolesAsync(updatePrincipalRolesRequest: new Cloudinary.Account.Provisioning.Models.Components.UpdatePrincipalRolesRequest() {
    Operation = OperationEnum.Add,
    Principal = new Principal() {
        Type = PrincipalTypeEnum.User,
        Id = "1234abc",
    },
    Roles = new List<RoleToManage>() {
        new RoleToManage() {
            Id = "marketing_content_contributor_1357fhe",
            ScopeId = "975l29lz02jt0836fhwi",
            PolicyParameters = new RoleToManagePolicyParameters() {},
        },
    },
});

// handle response
```
### Example Usage: missingPrincipalFieldsErrorExample

<!-- UsageSnippet language="csharp" operationID="updatePrincipalRoles" method="put" path="/v2/accounts/{account_id}/permissions/principal_roles" example="missingPrincipalFieldsErrorExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

await sdk.Principals.UpdateRolesAsync(updatePrincipalRolesRequest: new Cloudinary.Account.Provisioning.Models.Components.UpdatePrincipalRolesRequest() {
    Operation = OperationEnum.Add,
    Principal = new Principal() {
        Type = PrincipalTypeEnum.User,
        Id = "1234abc",
    },
    Roles = new List<RoleToManage>() {
        new RoleToManage() {
            Id = "marketing_content_contributor_1357fhe",
            ScopeId = "975l29lz02jt0836fhwi",
            PolicyParameters = new RoleToManagePolicyParameters() {},
        },
    },
});

// handle response
```

### Parameters

| Parameter                                                                                               | Type                                                                                                    | Required                                                                                                | Description                                                                                             |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `UpdatePrincipalRolesRequest`                                                                           | [Models.Components.UpdatePrincipalRolesRequest](../../Models/Components/UpdatePrincipalRolesRequest.md) | :heavy_check_mark:                                                                                      | Principal and roles details.                                                                            |
| `AccountId`                                                                                             | *string*                                                                                                | :heavy_minus_sign:                                                                                      | Account ID                                                                                              |

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 404                                                     | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Inspect

Retrieves principals and their assigned roles within a specified scope, based on query filters.

Use this endpoint to determine which users, groups, API keys, or account API keys have roles applied at:
* A specific `scope_type` ("account" or "prodenv")
* A specific `scope_id` (for product environments)
* Optional content filters (such as `folder_id`, `collection_id`, or `param_key` / `param_value`)
* Optional `principal_type` (and `principal_id`)

The response includes all principals that match the specified filters, along with the roles applied to them within that context.

This endpoint is useful when you want to:
* Audit who has access within a given scope
* Identify all principals assigned to roles for a specific folder, collection, asset, or product environment
* Retrieve role assignments dynamically based on filtering criteria


### Example Usage: InspectExampleAllFolders

<!-- UsageSnippet language="csharp" operationID="inspect" method="get" path="/v2/accounts/{account_id}/permissions/principal_roles/inspect" example="InspectExampleAllFolders" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

Models.Requests.InspectRequest req = new Cloudinary.Account.Provisioning.Models.Requests.InspectRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    PrincipalType = PrincipalTypeEnum.User,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Principals.InspectAsync(req);

// handle response
```
### Example Usage: InspectExampleFolder

<!-- UsageSnippet language="csharp" operationID="inspect" method="get" path="/v2/accounts/{account_id}/permissions/principal_roles/inspect" example="InspectExampleFolder" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

Models.Requests.InspectRequest req = new Cloudinary.Account.Provisioning.Models.Requests.InspectRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    PrincipalType = PrincipalTypeEnum.User,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Principals.InspectAsync(req);

// handle response
```
### Example Usage: InspectExampleProdEnv

<!-- UsageSnippet language="csharp" operationID="inspect" method="get" path="/v2/accounts/{account_id}/permissions/principal_roles/inspect" example="InspectExampleProdEnv" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

Models.Requests.InspectRequest req = new Cloudinary.Account.Provisioning.Models.Requests.InspectRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    PrincipalType = PrincipalTypeEnum.User,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Principals.InspectAsync(req);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `request`                                                                 | [Models.Requests.InspectRequest](../../Models/Requests/InspectRequest.md) | :heavy_check_mark:                                                        | The request object to use for the request.                                |

### Response

**[PrincipalRolesInspectResponse](../../Models/Components/PrincipalRolesInspectResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## InspectMultiple

Retrieves role assignments for a specified list of principals within a shared scope and optional policy parameters.

Use this endpoint when you already know which principals you want to evaluate and want to check their role assignments in a single request.

In this request:
* You explicitly provide the `principals` array in the request body.
* All principals are evaluated against the same `scope_type`, optional `scope_id`, and optional `policy_parameters`.
* Unlike `Inspect`, this endpoint doesn't search for matching principals. It evaluates only the principals you provide.

This endpoint is useful for:
* Verify role assignments for multiple specified principals at once
* Comparing role assignments across specific users, groups, or keys
* Reducing multiple per-principal `Inspect` calls into a single request


### Example Usage: InspectMultipleRequestExample

<!-- UsageSnippet language="csharp" operationID="inspectMultiple" method="post" path="/v2/accounts/{account_id}/permissions/principal_roles/inspect" example="InspectMultipleRequestExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.Principals.InspectMultipleAsync(inspectRequest: new Cloudinary.Account.Provisioning.Models.Components.InspectRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Principals = new List<Principal>() {
        new Principal() {
            Type = PrincipalTypeEnum.User,
            Id = "1234abc",
        },
        new Principal() {
            Type = PrincipalTypeEnum.User,
            Id = "4567xyz",
        },
        new Principal() {
            Type = PrincipalTypeEnum.ApiKey,
            Id = "a382ltieo893jhioqpg8urp",
        },
    },
    PolicyParameters = new InspectRequestPolicyParameters() {},
});

// handle response
```
### Example Usage: InspectMultipleResponseExample

<!-- UsageSnippet language="csharp" operationID="inspectMultiple" method="post" path="/v2/accounts/{account_id}/permissions/principal_roles/inspect" example="InspectMultipleResponseExample" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using System.Collections.Generic;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

var res = await sdk.Principals.InspectMultipleAsync(inspectRequest: new Cloudinary.Account.Provisioning.Models.Components.InspectRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    Principals = new List<Principal>() {
        new Principal() {
            Type = PrincipalTypeEnum.User,
            Id = "1234abc",
        },
    },
});

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `InspectRequest`                                                              | [Models.Components.InspectRequest](../../Models/Components/InspectRequest.md) | :heavy_check_mark:                                                            | Role assignments for multiple principals.                                     |
| `AccountId`                                                                   | *string*                                                                      | :heavy_minus_sign:                                                            | Account ID                                                                    |

### Response

**[PrincipalRolesInspectResponse](../../Models/Components/PrincipalRolesInspectResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |