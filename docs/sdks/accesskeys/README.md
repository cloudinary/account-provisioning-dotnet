# AccessKeys

## Overview

### Available Operations

* [List](#list) - Get access keys
* [Generate](#generate) - Generate an access key
* [DeleteByName](#deletebyname) - Delete access key by name
* [Update](#update) - Update an access key
* [Delete](#delete) - Delete access key

## List

Retrieve an array of all access keys for a product environment.

Learn more about retrieving access keys.
<https://cloudinary.com/documentation/provisioning_api#get_access_keys>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getAccessKeys" method="get" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}/access_keys" example="AccessKeys" -->
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

GetAccessKeysRequest req = new GetAccessKeysRequest() {
    SubAccountId = "abcde1fghij2klmno3pqrst4uvwxy5z",
    SortBy = SortBy.CreatedAt,
    SortOrder = SortOrder.Asc,
};

var res = await sdk.AccessKeys.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [GetAccessKeysRequest](../../Models/Requests/GetAccessKeysRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[AccessKeysResponse](../../Models/Components/AccessKeysResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 401, 404, 420, 429                                          | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Generate

Generate a new access key.

Learn more about generating access keys.
<https://cloudinary.com/documentation/provisioning_api#generate_an_access_key>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="generateAccessKey" method="post" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}/access_keys" example="MainAccessKey" -->
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

var res = await sdk.AccessKeys.GenerateAsync(
    subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z",
    accessKeyRequest: new AccessKeyRequest() {
        Name = "main_key",
        Enabled = true,
    }
);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     | Example                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `SubAccountId`                                                  | *string*                                                        | :heavy_check_mark:                                              | The ID of the product environment.                              | abcde1fghij2klmno3pqrst4uvwxy5z                                 |
| `AccessKeyRequest`                                              | [AccessKeyRequest](../../Models/Components/AccessKeyRequest.md) | :heavy_check_mark:                                              | Access key details.                                             |                                                                 |
| `AccountId`                                                     | *string*                                                        | :heavy_minus_sign:                                              | Account ID                                                      |                                                                 |

### Response

**[AccessKey](../../Models/Components/AccessKey.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## DeleteByName

Delete a specific access key by name.

Learn more about deleting access keys.
<https://cloudinary.com/documentation/provisioning_api#delete_an_access_key>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteAccessKeyByName" method="delete" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}/access_keys" -->
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

var res = await sdk.AccessKeys.DeleteByNameAsync(
    subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z",
    name: "main_key"
);

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        | Example                            |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `SubAccountId`                     | *string*                           | :heavy_check_mark:                 | The ID of the product environment. | abcde1fghij2klmno3pqrst4uvwxy5z    |
| `Name`                             | *string*                           | :heavy_check_mark:                 | The access key name.               | main_key                           |
| `AccountId`                        | *string*                           | :heavy_minus_sign:                 | Account ID                         |                                    |

### Response

**[SuccessResponse](../../Models/Components/SuccessResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Update

Update the name and/or status of an existing access key.

Learn more about updating access keys.
<https://cloudinary.com/documentation/provisioning_api#update_an_access_key>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="updateAccessKey" method="put" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}/access_keys/{key}" example="MainAccessKey" -->
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

var res = await sdk.AccessKeys.UpdateAsync(
    subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z",
    key: "814814814814814",
    accessKeyUpdateRequest: new AccessKeyUpdateRequest() {
        Name = "main_key",
        Enabled = true,
        DedicatedFor = DedicatedFor.Webhooks,
    }
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 | Example                                                                     |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `SubAccountId`                                                              | *string*                                                                    | :heavy_check_mark:                                                          | The ID of the product environment.                                          | abcde1fghij2klmno3pqrst4uvwxy5z                                             |
| `Key`                                                                       | *string*                                                                    | :heavy_check_mark:                                                          | The access key (api key).                                                   | 814814814814814                                                             |
| `AccessKeyUpdateRequest`                                                    | [AccessKeyUpdateRequest](../../Models/Components/AccessKeyUpdateRequest.md) | :heavy_check_mark:                                                          | Access key details for update.                                              |                                                                             |
| `AccountId`                                                                 | *string*                                                                    | :heavy_minus_sign:                                                          | Account ID                                                                  |                                                                             |

### Response

**[AccessKey](../../Models/Components/AccessKey.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Delete

Delete a specific access key.

Learn more about deleting access keys.
<https://cloudinary.com/documentation/provisioning_api#delete_an_access_key>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteAccessKey" method="delete" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}/access_keys/{key}" -->
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

var res = await sdk.AccessKeys.DeleteAsync(
    subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z",
    key: "814814814814814"
);

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        | Example                            |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `SubAccountId`                     | *string*                           | :heavy_check_mark:                 | The ID of the product environment. | abcde1fghij2klmno3pqrst4uvwxy5z    |
| `Key`                              | *string*                           | :heavy_check_mark:                 | The access key (api key).          | 814814814814814                    |
| `AccountId`                        | *string*                           | :heavy_minus_sign:                 | Account ID                         |                                    |

### Response

**[SuccessResponse](../../Models/Components/SuccessResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |