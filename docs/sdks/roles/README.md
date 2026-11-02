# Roles

## Overview

All roles include one or more predefined **system policies**, and can be applied to principals to enforce these policies.

You can **manage custom roles**, where you select the system policies. 

You can **view system roles**, which contain a fixed set of system policies and are provided by Cloudinary.


### Available Operations

* [List](#list) - Get roles
* [Create](#create) - Create custom role
* [Get](#get) - Get role
* [Update](#update) - Update custom role
* [Delete](#delete) - Delete custom role
* [ListPrincipals](#listprincipals) - Get a role's principals
* [UpdatePrincipals](#updateprincipals) - Assign principals to a role

## List

Retrieve all system and custom roles of a specific `permission_type` (global or content-specific). Optionally filter by `scope_type`, `management_type`, and `policy_parameters`.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getRoles" method="get" path="/v2/accounts/{account_id}/permissions/roles" example="GetRolesExample" -->
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

GetRolesRequest req = new GetRolesRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
    PermissionType = PermissionTypeEnum.Global,
    ManagementType = ManagementTypeEnum.System,
};

var res = await sdk.Roles.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [GetRolesRequest](../../Models/Requests/GetRolesRequest.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[RolesResponse](../../Models/Components/RolesResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403                                                               | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Create

Create a new custom role.

### Example Usage: createAcctRoleExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createAcctRoleExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "sensitive_account_details_manager_88825hl",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Account,
    Name = "Sensitive account details manager",
    Description = "Responsible for managing users and account security.",
    SystemPolicyIds = new List<string>() {
        "cld::global::users_and_groups::manage",
        "cld::policy::global::account_security::manage",
    },
});

// handle response
```
### Example Usage: createAcctRoleResponseExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createAcctRoleResponseExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing upload presets and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```
### Example Usage: createContentRoleExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createContentRoleExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "marketing_content_contributor_1357fhe",
    PermissionType = "content",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Marketing content contributor",
    Description = "View all assets in selected folders and contribute to those folders, without permission to download.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::content::folder::view_download",
        "cld::policy::content::folder::add_assets",
    },
});

// handle response
```
### Example Usage: createContentRoleResponseExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createContentRoleResponseExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing upload presets and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```
### Example Usage: createGlobalRoleExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createGlobalRoleExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing uploads and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```
### Example Usage: createGlobalRoleResponseExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="createGlobalRoleResponseExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing upload presets and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```
### Example Usage: invalidFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="invalidFieldErrorExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing upload presets and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```
### Example Usage: missingFieldsErrorExample

<!-- UsageSnippet language="csharp" operationID="createRole" method="post" path="/v2/accounts/{account_id}/permissions/roles" example="missingFieldsErrorExample" -->
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

var res = await sdk.Roles.CreateAsync(createRole: new CreateRole() {
    Id = "upload_manager_12334565",
    PermissionType = "global",
    ScopeType = ScopeTypeEnum.Prodenv,
    Name = "Upload manager",
    Description = "Responsible for managing upload presets and uploading new assets.",
    SystemPolicyIds = new List<string>() {
        "cld::policy::global::upload_presets::manage",
        "cld::policy::global::folder_and_asset_management::create_asset",
    },
});

// handle response
```

### Parameters

| Parameter                                           | Type                                                | Required                                            | Description                                         |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| `CreateRole`                                        | [CreateRole](../../Models/Components/CreateRole.md) | :heavy_check_mark:                                  | Role details.                                       |
| `AccountId`                                         | *string*                                            | :heavy_minus_sign:                                  | Account ID                                          |

### Response

**[RoleResponse](../../Models/Components/RoleResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 409                                                     | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Get

Get a specific system or custom role.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getRole" method="get" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" example="GetRoleExample" -->
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

GetRoleRequest req = new GetRoleRequest() {
    RoleId = "<id>",
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Roles.GetAsync(req);

// handle response
```

### Parameters

| Parameter                                                 | Type                                                      | Required                                                  | Description                                               |
| --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- | --------------------------------------------------------- |
| `request`                                                 | [GetRoleRequest](../../Models/Requests/GetRoleRequest.md) | :heavy_check_mark:                                        | The request object to use for the request.                |

### Response

**[RoleResponse](../../Models/Components/RoleResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Update

Update a specific custom role by providing all relevant details, including those you want to keep as-is.

*Note:* Updating a role with a name that already exists will trigger a 409 error.


### Example Usage: invalidPolicyIDFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="updateRole" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" example="invalidPolicyIDFieldErrorExample" -->
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

var res = await sdk.Roles.UpdateAsync(
    roleId: "<id>",
    updateRole: new UpdateRole() {
        Name = "Upload manager",
        Description = "Responsible for managing upload presets and uploading new assets.",
        SystemPolicyIds = new List<string>() {
            "cld::policy::global::upload_presets::manage",
            "cld::policy::global::folder_and_asset_management::create_asset",
        },
    }
);

// handle response
```
### Example Usage: missingFieldsErrorExample

<!-- UsageSnippet language="csharp" operationID="updateRole" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" example="missingFieldsErrorExample" -->
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

var res = await sdk.Roles.UpdateAsync(
    roleId: "<id>",
    updateRole: new UpdateRole() {
        Name = "Upload manager",
        Description = "Responsible for managing upload presets and uploading new assets.",
        SystemPolicyIds = new List<string>() {
            "cld::policy::global::upload_presets::manage",
            "cld::policy::global::folder_and_asset_management::create_asset",
        },
    }
);

// handle response
```
### Example Usage: updatePolicyResponse

<!-- UsageSnippet language="csharp" operationID="updateRole" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" example="updatePolicyResponse" -->
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

var res = await sdk.Roles.UpdateAsync(
    roleId: "<id>",
    updateRole: new UpdateRole() {
        Name = "Upload manager",
        Description = "Responsible for managing upload presets and uploading new assets.",
        SystemPolicyIds = new List<string>() {
            "cld::policy::global::upload_presets::manage",
            "cld::policy::global::folder_and_asset_management::create_asset",
        },
    }
);

// handle response
```
### Example Usage: updateRoleExample

<!-- UsageSnippet language="csharp" operationID="updateRole" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" example="updateRoleExample" -->
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

var res = await sdk.Roles.UpdateAsync(
    roleId: "<id>",
    updateRole: new UpdateRole() {
        Name = "Upload manager",
        Description = "Responsible for managing uploads and uploading new assets.",
        SystemPolicyIds = new List<string>() {
            "cld::policy::global::upload_presets::manage",
            "cld::policy::global::folder_and_asset_management::create_asset",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                           | Type                                                | Required                                            | Description                                         |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| `RoleId`                                            | *string*                                            | :heavy_check_mark:                                  | A unique identifier for the role.                   |
| `UpdateRole`                                        | [UpdateRole](../../Models/Components/UpdateRole.md) | :heavy_check_mark:                                  | Role details                                        |
| `AccountId`                                         | *string*                                            | :heavy_minus_sign:                                  | Account ID                                          |

### Response

**[RoleResponse](../../Models/Components/RoleResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 404, 409                                                | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Delete

Delete a specific custom role.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteRole" method="delete" path="/v2/accounts/{account_id}/permissions/roles/{role_id}" -->
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

await sdk.Roles.DeleteAsync(roleId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                                                                               | Type                                                                                                                                                                                                                                                                                                    | Required                                                                                                                                                                                                                                                                                                | Description                                                                                                                                                                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `RoleId`                                                                                                                                                                                                                                                                                                | *string*                                                                                                                                                                                                                                                                                                | :heavy_check_mark:                                                                                                                                                                                                                                                                                      | A unique identifier for the role.                                                                                                                                                                                                                                                                       |
| `AccountId`                                                                                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                                                                                | :heavy_minus_sign:                                                                                                                                                                                                                                                                                      | Account ID                                                                                                                                                                                                                                                                                              |
| `Force`                                                                                                                                                                                                                                                                                                 | *bool*                                                                                                                                                                                                                                                                                                  | :heavy_minus_sign:                                                                                                                                                                                                                                                                                      | Determines whether the role should be deleted when it has associated principals.<br/>- `true`: Deletes the role even if it has associated principals.<br/>- `false` (default): Prevents deletion if the role has associated principals. You must manually unassociate the principals before deleting the role.<br/> |

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## ListPrincipals

Retrieve all principals associated with a specific role.

### Example Usage: GetRolePrincipalsExample

<!-- UsageSnippet language="csharp" operationID="getRolePrincipals" method="get" path="/v2/accounts/{account_id}/permissions/roles/{role_id}/principals" example="GetRolePrincipalsExample" -->
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

GetRolePrincipalsRequest req = new GetRolePrincipalsRequest() {
    RoleId = "<id>",
    ScopeType = ScopeTypeEnum.Prodenv,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Roles.ListPrincipalsAsync(req);

// handle response
```
### Example Usage: GetRolePrincipalsWithParamKeyValueExample

<!-- UsageSnippet language="csharp" operationID="getRolePrincipals" method="get" path="/v2/accounts/{account_id}/permissions/roles/{role_id}/principals" example="GetRolePrincipalsWithParamKeyValueExample" -->
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

GetRolePrincipalsRequest req = new GetRolePrincipalsRequest() {
    RoleId = "<id>",
    ScopeType = ScopeTypeEnum.Prodenv,
    ParamKey = new List<string>() {
        "folder_id",
    },
    ParamValue = new List<string>() {
        "asdfjkl12347890",
    },
};

var res = await sdk.Roles.ListPrincipalsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [GetRolePrincipalsRequest](../../Models/Requests/GetRolePrincipalsRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[PrincipalsResponse](../../Models/Components/PrincipalsResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## UpdatePrincipals

Add or remove principals associated with a role.

### Example Usage: invalidOperationFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="updateRolePrincipals" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}/principals" example="invalidOperationFieldErrorExample" -->
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

await sdk.Roles.UpdatePrincipalsAsync(
    roleId: "<id>",
    updateRolePrincipalsRequest: new Cloudinary.Account.Provisioning.Models.Components.UpdateRolePrincipalsRequest() {
        Operation = OperationEnum.Add,
        Principals = new List<UpdateRolePrincipal>() {
            new UpdateRolePrincipal() {
                PrincipalType = PrincipalTypeEnum.User,
                PrincipalId = "1234abc",
                ScopeId = "975l29lz02jt0836fhwi",
                PolicyParameters = new Dictionary<string, object>() {

                },
            },
        },
    }
);

// handle response
```
### Example Usage: missingFieldsErrorExample

<!-- UsageSnippet language="csharp" operationID="updateRolePrincipals" method="put" path="/v2/accounts/{account_id}/permissions/roles/{role_id}/principals" example="missingFieldsErrorExample" -->
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

await sdk.Roles.UpdatePrincipalsAsync(
    roleId: "<id>",
    updateRolePrincipalsRequest: new Cloudinary.Account.Provisioning.Models.Components.UpdateRolePrincipalsRequest() {
        Operation = OperationEnum.Add,
        Principals = new List<UpdateRolePrincipal>() {
            new UpdateRolePrincipal() {
                PrincipalType = PrincipalTypeEnum.User,
                PrincipalId = "1234abc",
                ScopeId = "975l29lz02jt0836fhwi",
                PolicyParameters = new Dictionary<string, object>() {

                },
            },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                               | Type                                                                                                    | Required                                                                                                | Description                                                                                             |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `RoleId`                                                                                                | *string*                                                                                                | :heavy_check_mark:                                                                                      | A unique identifier for the role.                                                                       |
| `UpdateRolePrincipalsRequest`                                                                           | [Models.Components.UpdateRolePrincipalsRequest](../../Models/Components/UpdateRolePrincipalsRequest.md) | :heavy_check_mark:                                                                                      | Principals details.                                                                                     |
| `AccountId`                                                                                             | *string*                                                                                                | :heavy_minus_sign:                                                                                      | Account ID                                                                                              |

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 404                                                     | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |