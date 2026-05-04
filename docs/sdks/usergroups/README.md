# UserGroups

## Overview

### Available Operations

* [List](#list) - Get User Groups
* [Create](#create) - Create User Group
* [Get](#get) - Get User Group
* [Update](#update) - Update User Group
* [Delete](#delete) - Delete User Group
* [ListUsers](#listusers) - Get Users in User Group
* [AddUser](#adduser) - Add User to User Group
* [RemoveUser](#removeuser) - Remove User from User Group

## List

Retrieve an array of all user groups in the account.

Learn more about retrieving user groups.
<https://cloudinary.com/documentation/provisioning_api#get_user_groups>

### Example Usage: UserGroups

<!-- UsageSnippet language="csharp" operationID="getUserGroups" method="get" path="/v1_1/provisioning/accounts/{account_id}/user_groups" example="UserGroups" -->
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

var res = await sdk.UserGroups.ListAsync(extendedDetails: true);

// handle response
```
### Example Usage: UserGroupsExtendedDetails

<!-- UsageSnippet language="csharp" operationID="getUserGroups" method="get" path="/v1_1/provisioning/accounts/{account_id}/user_groups" example="UserGroupsExtendedDetails" -->
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

var res = await sdk.UserGroups.ListAsync(extendedDetails: true);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               | Example                                                                                                   |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `AccountId`                                                                                               | *string*                                                                                                  | :heavy_minus_sign:                                                                                        | Account ID                                                                                                |                                                                                                           |
| `ExtendedDetails`                                                                                         | *bool*                                                                                                    | :heavy_minus_sign:                                                                                        | Whether to only return extended (true) or basic information about the group (false).<br/>**Default**: false.<br/> | true                                                                                                      |

### Response

**[UserGroupsResponse](../../Models/Components/UserGroupsResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Create

Create a new user group for the account.

Learn more about creating user groups.
<https://cloudinary.com/documentation/provisioning_api#create_user_group>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createUserGroup" method="post" path="/v1_1/provisioning/accounts/{account_id}/user_groups" example="UserGroupDesigners" -->
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

var res = await sdk.UserGroups.CreateAsync(userGroupRequest: new UserGroupRequest() {
    Name = "Designers",
    ExtendedDetails = false,
});

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `UserGroupRequest`                                              | [UserGroupRequest](../../Models/Components/UserGroupRequest.md) | :heavy_check_mark:                                              | User group details.                                             |
| `AccountId`                                                     | *string*                                                        | :heavy_minus_sign:                                              | Account ID                                                      |

### Response

**[UserGroup](../../Models/Components/UserGroup.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Get

Retrieve a specific user group.

Learn more about retrieving a specific user group.
<https://cloudinary.com/documentation/provisioning_api#get_user_group>

### Example Usage: UserGroupDesigners

<!-- UsageSnippet language="csharp" operationID="getUserGroup" method="get" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}" example="UserGroupDesigners" -->
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

var res = await sdk.UserGroups.GetAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    extendedDetails: true
);

// handle response
```
### Example Usage: UserGroupDesignersExtendedDetails

<!-- UsageSnippet language="csharp" operationID="getUserGroup" method="get" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}" example="UserGroupDesignersExtendedDetails" -->
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

var res = await sdk.UserGroups.GetAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    extendedDetails: true
);

// handle response
```

### Parameters

| Parameter                                                                                                 | Type                                                                                                      | Required                                                                                                  | Description                                                                                               | Example                                                                                                   |
| --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| `GroupId`                                                                                                 | *string*                                                                                                  | :heavy_check_mark:                                                                                        | The ID of the user group.                                                                                 | 7f08f1f1fc910bf1f25274aef11d27                                                                            |
| `AccountId`                                                                                               | *string*                                                                                                  | :heavy_minus_sign:                                                                                        | Account ID                                                                                                |                                                                                                           |
| `ExtendedDetails`                                                                                         | *bool*                                                                                                    | :heavy_minus_sign:                                                                                        | Whether to only return extended (true) or basic information about the group (false).<br/>**Default**: false.<br/> | true                                                                                                      |

### Response

**[UserGroup](../../Models/Components/UserGroup.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Update

Update the name of a specified user group.

Learn more about updating a specific user group.
<https://cloudinary.com/documentation/provisioning_api#update_user_group>

### Example Usage: UserGroupDesignersRequest

<!-- UsageSnippet language="csharp" operationID="updateUserGroup" method="put" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}" example="UserGroupDesignersRequest" -->
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

var res = await sdk.UserGroups.UpdateAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    userGroupRequest: new UserGroupRequest() {
        Name = "Designers and Creatives",
    }
);

// handle response
```
### Example Usage: UserGroupUpdate

<!-- UsageSnippet language="csharp" operationID="updateUserGroup" method="put" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}" example="UserGroupUpdate" -->
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

var res = await sdk.UserGroups.UpdateAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    userGroupRequest: new UserGroupRequest() {
        Name = "Designers",
        ExtendedDetails = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     | Example                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `GroupId`                                                       | *string*                                                        | :heavy_check_mark:                                              | The ID of the user group.                                       | 7f08f1f1fc910bf1f25274aef11d27                                  |
| `UserGroupRequest`                                              | [UserGroupRequest](../../Models/Components/UserGroupRequest.md) | :heavy_check_mark:                                              | User group details to update.                                   |                                                                 |
| `AccountId`                                                     | *string*                                                        | :heavy_minus_sign:                                              | Account ID                                                      |                                                                 |

### Response

**[UserGroup](../../Models/Components/UserGroup.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Delete

Delete a user group with the specified ID.

Learn more about deleting a specific user group.
<https://cloudinary.com/documentation/provisioning_api#delete_user_group>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteUserGroup" method="delete" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}" -->
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

var res = await sdk.UserGroups.DeleteAsync(groupId: "7f08f1f1fc910bf1f25274aef11d27");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `GroupId`                      | *string*                       | :heavy_check_mark:             | The ID of the user group.      | 7f08f1f1fc910bf1f25274aef11d27 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[SuccessResponse](../../Models/Components/SuccessResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## ListUsers

Retrieve the users in the group with the specified ID.

Learn more about retrieving users in a specific user group.
<https://cloudinary.com/documentation/provisioning_api#get_user_group_users>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getUsersInUserGroup" method="get" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}/users" example="UserGroupUsers" -->
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

var res = await sdk.UserGroups.ListUsersAsync(groupId: "7f08f1f1fc910bf1f25274aef11d27");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `GroupId`                      | *string*                       | :heavy_check_mark:             | The ID of the user group.      | 7f08f1f1fc910bf1f25274aef11d27 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[UserGroupUsersResponse](../../Models/Components/UserGroupUsersResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## AddUser

Add a user to a group with the specified ID.

Learn more about adding users to a specific user group.
<https://cloudinary.com/documentation/provisioning_api#add_user_to_group>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="addUserToUserGroup" method="post" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}/users/{user_id}" example="UserGroupUserJohn" -->
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

var res = await sdk.UserGroups.AddUserAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    userId: "0abed8dfcc039ea05e2a1d494fd442"
);

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `GroupId`                      | *string*                       | :heavy_check_mark:             | The ID of the user group.      | 7f08f1f1fc910bf1f25274aef11d27 |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[UserGroupUser](../../Models/Components/UserGroupUser.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## RemoveUser

Remove a user from a group with the specified ID.

Learn more about removing users from a specific user group.
<https://cloudinary.com/documentation/provisioning_api#remove_user_from_group>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="removeUserFromUserGroup" method="delete" path="/v1_1/provisioning/accounts/{account_id}/user_groups/{group_id}/users/{user_id}" example="UserGroupUsers" -->
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

var res = await sdk.UserGroups.RemoveUserAsync(
    groupId: "7f08f1f1fc910bf1f25274aef11d27",
    userId: "0abed8dfcc039ea05e2a1d494fd442"
);

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `GroupId`                      | *string*                       | :heavy_check_mark:             | The ID of the user group.      | 7f08f1f1fc910bf1f25274aef11d27 |
| `UserId`                       | *string*                       | :heavy_check_mark:             | The ID of the user.            | 0abed8dfcc039ea05e2a1d494fd442 |
| `AccountId`                    | *string*                       | :heavy_minus_sign:             | Account ID                     |                                |

### Response

**[UserGroupUsersResponse](../../Models/Components/UserGroupUsersResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |