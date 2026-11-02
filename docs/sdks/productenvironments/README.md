# ProductEnvironments

## Overview

### Available Operations

* [List](#list) - Get product environments
* [Create](#create) - Create product environment
* [Get](#get) - Get product environment
* [Update](#update) - Update product environment
* [Delete](#delete) - Delete product environment

## List

Return an array of all product environments, or if conditions are specified, 
return the relevant product environments.


Learn more about getting product environments.
<https://cloudinary.com/documentation/provisioning_api#get_product_environments>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getProductEnvironments" method="get" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts" example="ProductEnvironments" -->
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

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [GetProductEnvironmentsRequest](../../Models/Requests/GetProductEnvironmentsRequest.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[ProductEnvironmentsResponse](../../Models/Components/ProductEnvironmentsResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Create

Create a new product environment. Any users that have access to all product environments will also automatically
have access to the new product environment.


Learn more about creating product environments.
<https://cloudinary.com/documentation/provisioning_api#create_product_environment>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="createProductEnvironment" method="post" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts" example="ProductEnvironment3" -->
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

var res = await sdk.ProductEnvironments.CreateAsync(productEnvironmentRequest: new ProductEnvironmentRequest() {
    Name = "Product3 Application",
    CloudName = "product3",
    BaseSubAccountId = "0aaaaa1bbbbb2ccccc3ddddd4eeeee5f",
});

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `ProductEnvironmentRequest`                                                       | [ProductEnvironmentRequest](../../Models/Components/ProductEnvironmentRequest.md) | :heavy_check_mark:                                                                | Product environment details.                                                      |
| `AccountId`                                                                       | *string*                                                                          | :heavy_minus_sign:                                                                | Account ID                                                                        |

### Response

**[ProductEnvironment](../../Models/Components/ProductEnvironment.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 409, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Get

Retrieve a specific product environment.

Learn more about retrieving specific product environments.
<https://cloudinary.com/documentation/provisioning_api#get_product_environment>

### Example Usage: ProductEnvironment1

<!-- UsageSnippet language="csharp" operationID="getProductEnvironment" method="get" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}" example="ProductEnvironment1" -->
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

var res = await sdk.ProductEnvironments.GetAsync(subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z");

// handle response
```
### Example Usage: ProductEnvironment2

<!-- UsageSnippet language="csharp" operationID="getProductEnvironment" method="get" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}" example="ProductEnvironment2" -->
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

var res = await sdk.ProductEnvironments.GetAsync(subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z");

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        | Example                            |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `SubAccountId`                     | *string*                           | :heavy_check_mark:                 | The ID of the product environment. | abcde1fghij2klmno3pqrst4uvwxy5z    |
| `AccountId`                        | *string*                           | :heavy_minus_sign:                 | Account ID                         |                                    |

### Response

**[ProductEnvironment](../../Models/Components/ProductEnvironment.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 404, 420, 429                                     | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Update

Update the details of a product environment.

Learn more about updating product environments.
<https://cloudinary.com/documentation/provisioning_api#update_product_environment>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="updateProductEnvironment" method="put" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}" example="ProductEnvironment1" -->
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

var res = await sdk.ProductEnvironments.UpdateAsync(
    subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z",
    productEnvironmentUpdateRequest: new ProductEnvironmentUpdateRequest() {
        Name = "Product3 Application",
        CloudName = "product3",
    }
);

// handle response
```

### Parameters

| Parameter                                                                                     | Type                                                                                          | Required                                                                                      | Description                                                                                   | Example                                                                                       |
| --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------- |
| `SubAccountId`                                                                                | *string*                                                                                      | :heavy_check_mark:                                                                            | The ID of the product environment.                                                            | abcde1fghij2klmno3pqrst4uvwxy5z                                                               |
| `ProductEnvironmentUpdateRequest`                                                             | [ProductEnvironmentUpdateRequest](../../Models/Components/ProductEnvironmentUpdateRequest.md) | :heavy_check_mark:                                                                            | Product environment details to update.                                                        |                                                                                               |
| `AccountId`                                                                                   | *string*                                                                                      | :heavy_minus_sign:                                                                            | Account ID                                                                                    |                                                                                               |

### Response

**[ProductEnvironment](../../Models/Components/ProductEnvironment.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 409, 420, 429                           | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |

## Delete

Delete a specific product environment.

Learn more about deleting product environments.
<https://cloudinary.com/documentation/provisioning_api#delete_product_environment>

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteProductEnvironment" method="delete" path="/v1_1/provisioning/accounts/{account_id}/sub_accounts/{sub_account_id}" -->
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

var res = await sdk.ProductEnvironments.DeleteAsync(subAccountId: "abcde1fghij2klmno3pqrst4uvwxy5z");

// handle response
```

### Parameters

| Parameter                          | Type                               | Required                           | Description                        | Example                            |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `SubAccountId`                     | *string*                           | :heavy_check_mark:                 | The ID of the product environment. | abcde1fghij2klmno3pqrst4uvwxy5z    |
| `AccountId`                        | *string*                           | :heavy_minus_sign:                 | Account ID                         |                                    |

### Response

**[SuccessResponse](../../Models/Components/SuccessResponse.md)**

### Errors

| Error Type                                                  | Status Code                                                 | Content Type                                                |
| ----------------------------------------------------------- | ----------------------------------------------------------- | ----------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.ErrorResponse | 400, 401, 403, 404, 420, 429                                | application/json                                            |
| Cloudinary.Account.Provisioning.Models.Errors.APIException  | 4XX, 5XX                                                    | \*/\*                                                       |