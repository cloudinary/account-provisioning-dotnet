# Users

## Overview

Manage the users for your account.


Learn more about users management.
<https://cloudinary.com/documentation/provisioning_api#users>

### Available Operations

* [List](#list) - Get users
* [Create](#create) - Create user
* [Get](#get) - Get user
* [Update](#update) - Update user
* [Delete](#delete) - Delete user
* [GetGroups](#getgroups) - Get user groups
* [ListSubAccounts](#listsubaccounts) - Get user sub-accounts

## List

Returns an array of all users in the account, or if conditions are specified, returns the relevant users.


Learn more about retrieving users.
<https://cloudinary.com/documentation/provisioning_api#get_users>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getUsers" method="get" path="/v1_1/provisioning/accounts/{account_id}/users" example="Users" -->
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;
using System;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

GetUsersRequest req = new GetUsersRequest() {
    Pending = false,
    Prefix = "john",
    From = DateOnly.Parse("2023-01-01T00:00:00Z"),
    To = DateOnly.Parse("2024-12-31T00:00:00Z"),
};

var res = await sdk.Users.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                   | Type                                                        | Required                                                    | Description                                                 |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| `request`                                                   | [GetUsersRequest](../../Models/Requests/GetUsersRequest.md) | :heavy_check_mark:                                          | The request object to use for the request.                  |

### Response

**[UsersResponse](../../Models/Components/UsersResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Create

Create a new user.

Learn more about creating users.
<https://cloudinary.com/documentation/provisioning_api#create_user>

### Example Usage: CreateUserExample

<!-- UsageSnippet language="csharp" operationID="createUser" method="post" path="/v1_1/provisioning/accounts/{account_id}/users" example="CreateUserExample" -->
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

var res = await sdk.Users.CreateAsync(requestBody: new CreateUserRequestBody() {
    Name = "jenny_bar",
    Email = "jenny_bar@example.com",
    Role = Role.MasterAdmin,
});

// handle response
```
### Example Usage: UserResponseExample

<!-- UsageSnippet language="csharp" operationID="createUser" method="post" path="/v1_1/provisioning/accounts/{account_id}/users" example="UserResponseExample" -->
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

var res = await sdk.Users.CreateAsync(requestBody: new CreateUserRequestBody() {
    Name = "John",
    Email = "john@example.com",
    Enabled = true,
    Roles = new List<RoleAssignment>() {
        new RoleAssignment() {
            Id = "media_library_admin",
        },
    },
});

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `RequestBody`                                                           | [CreateUserRequestBody](../../Models/Requests/CreateUserRequestBody.md) | :heavy_check_mark:                                                      | User details.                                                           |
| `AccountId`                                                             | *string*                                                                | :heavy_minus_sign:                                                      | Account ID                                                              |

### Response

**[User](../../Models/Components/User.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Get

Retrieve a specific user.

Learn more about retrieving a specific user.
<https://cloudinary.com/documentation/provisioning_api#get_user>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getUser" method="get" path="/v1_1/provisioning/accounts/{account_id}/users/{user_id}" example="UserResponseExample" -->
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

var res = await sdk.Users.GetAsync(userId: "0abed8dfcc039ea05e2a1d494fd442");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[User](../../Models/Components/User.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Update

Update the details of a user.

Learn more about updating a specific user.
<https://cloudinary.com/documentation/provisioning_api#update_user>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="updateUser" method="put" path="/v1_1/provisioning/accounts/{account_id}/users/{user_id}" example="UserJohn" -->
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

var res = await sdk.Users.UpdateAsync(
    userId: "0abed8dfcc039ea05e2a1d494fd442",
    requestBody: new UpdateUserRequestBody() {
        Name = "John",
        Email = "john@example.com",
        Enabled = true,
        RoleManagement = new RoleManagementRequest() {
            Operation = Operation.Add,
            Roles = new List<RoleAssignment>() {},
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `UserId`                                                                | *string*                                                                | :heavy_check_mark:                                                      | The ID of the user.                                                     | 0abed8dfcc039ea05e2a1d494fd442                                          |
| `RequestBody`                                                           | [UpdateUserRequestBody](../../Models/Requests/UpdateUserRequestBody.md) | :heavy_check_mark:                                                      | User details to update.                                                 |                                                                         |
| `AccountId`                                                             | *string*                                                                | :heavy_minus_sign:                                                      | Account ID                                                              |                                                                         |

### Response

**[User](../../Models/Components/User.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Delete

Delete a specific user.

Learn more about deleting a specific user.
<https://cloudinary.com/documentation/provisioning_api#delete_user>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteUser" method="delete" path="/v1_1/provisioning/accounts/{account_id}/users/{user_id}" -->
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

var res = await sdk.Users.DeleteAsync(userId: "0abed8dfcc039ea05e2a1d494fd442");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[SuccessResponse](../../Models/Components/SuccessResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## GetGroups

Retrieve the groups that a specific user belongs to.

Learn more about retrieving user groups.
<https://cloudinary.com/documentation/provisioning_api#get_users_groups>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getGroupsForUser" method="get" path="/v1_1/provisioning/accounts/{account_id}/users/{user_id}/groups" example="UserGroupsList" -->
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

var res = await sdk.Users.GetGroupsAsync(userId: "0abed8dfcc039ea05e2a1d494fd442");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[UserGroupsListResponse](../../Models/Components/UserGroupsListResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## ListSubAccounts

Retrieve the product environments (sub-accounts) that a specific user has access to.

Learn more about retrieving user sub-accounts.
<https://cloudinary.com/documentation/provisioning_api#get_user_sub_accounts>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getSubAccountsForUser" method="get" path="/v1_1/provisioning/accounts/{account_id}/users/{user_id}/sub_accounts" example="UserSubAccounts" -->
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

var res = await sdk.Users.ListSubAccountsAsync(userId: "0abed8dfcc039ea05e2a1d494fd442");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[UserSubAccountsResponse](../../Models/Components/UserSubAccountsResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |