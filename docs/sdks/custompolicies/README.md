# CustomPolicies

## Overview

### Available Operations

* [List](#list) - Get custom policies
* [Create](#create) - Create custom policy
* [Get](#get) - Get custom policy
* [Update](#update) - Update custom policy
* [Delete](#delete) - Delete custom policy

## List

Retrieve all custom permission policies defined for a specific scope. The scope can be at the account level or within a specific product environment.

**Notes:**
  * If `scope_type` isn't specified as `prodenv`, the account-level policies will be returned.

  * If `scope_type` is specified as `prodenv`, `scope_id` is required.


### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustomPolicies" method="get" path="/v2/accounts/{account_id}/permissions/policies/custom" example="CustomPoliciesExample" -->
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

GetCustomPoliciesRequest req = new GetCustomPoliciesRequest() {
    ScopeType = ScopeTypeEnum.Prodenv,
};

var res = await sdk.CustomPolicies.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `request`                                                                     | [GetCustomPoliciesRequest](../../Models/Requests/GetCustomPoliciesRequest.md) | :heavy_check_mark:                                                            | The request object to use for the request.                                    |

### Response

**[CustomPoliciesResponse](../../Models/Components/CustomPoliciesResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403                                                               | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Create

Create a new custom policy with a statement defined in Cedar. This policy specifies permissions for a principal, allowing a specific action on a designated resource, within a particular scope.

Learn more about creating a new custom policy
<https://cloudinary.com/documentation/permissions_api_guide#create_a_policy_statement>

### Example Usage: cedarErrorExample

<!-- UsageSnippet language="csharp" operationID="createCustomPolicy" method="post" path="/v2/accounts/{account_id}/permissions/policies/custom" example="cedarErrorExample" -->
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

var res = await sdk.CustomPolicies.CreateAsync(createCustomPolicy: new CreateCustomPolicy() {
    PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
    ",
    Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Name = "Read access to Clothing folder",
});

// handle response
```
### Example Usage: createCustomPolicyExample

<!-- UsageSnippet language="csharp" operationID="createCustomPolicy" method="post" path="/v2/accounts/{account_id}/permissions/policies/custom" example="createCustomPolicyExample" -->
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

var res = await sdk.CustomPolicies.CreateAsync(createCustomPolicy: new CreateCustomPolicy() {
    PolicyStatement = "permit(principal == Cloudinary::APIKey::\"1234\",action==Cloudinary::Action::\"read\",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\"asdfjkl12347890\")} ;",
    Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Name = "Read access to Clothing folder",
});

// handle response
```
### Example Usage: createPolicyResponse

<!-- UsageSnippet language="csharp" operationID="createCustomPolicy" method="post" path="/v2/accounts/{account_id}/permissions/policies/custom" example="createPolicyResponse" -->
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

var res = await sdk.CustomPolicies.CreateAsync(createCustomPolicy: new CreateCustomPolicy() {
    PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
    ",
    Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Name = "Read access to Clothing folder",
});

// handle response
```
### Example Usage: invalidFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="createCustomPolicy" method="post" path="/v2/accounts/{account_id}/permissions/policies/custom" example="invalidFieldErrorExample" -->
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

var res = await sdk.CustomPolicies.CreateAsync(createCustomPolicy: new CreateCustomPolicy() {
    PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
    ",
    Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Name = "Read access to Clothing folder",
});

// handle response
```
### Example Usage: missingFieldsErrorExample

<!-- UsageSnippet language="csharp" operationID="createCustomPolicy" method="post" path="/v2/accounts/{account_id}/permissions/policies/custom" example="missingFieldsErrorExample" -->
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

var res = await sdk.CustomPolicies.CreateAsync(createCustomPolicy: new CreateCustomPolicy() {
    PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
    ",
    Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
    ScopeType = ScopeTypeEnum.Prodenv,
    ScopeId = "975l29lz02jt0836fhwi",
    Name = "Read access to Clothing folder",
});

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `CreateCustomPolicy`                                                | [CreateCustomPolicy](../../Models/Components/CreateCustomPolicy.md) | :heavy_check_mark:                                                  | Policy details.                                                     |
| `AccountId`                                                         | *string*                                                            | :heavy_minus_sign:                                                  | Account ID                                                          |

### Response

**[CustomPolicyResponse](../../Models/Components/CustomPolicyResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 409                                                     | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Get

Get a specific custom policy.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="getCustomPolicy" method="get" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="CustomPolicyExample" -->
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

var res = await sdk.CustomPolicies.GetAsync(policyId: "<id>");

// handle response
```

### Parameters

| Parameter                                             | Type                                                  | Required                                              | Description                                           |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| `PolicyId`                                            | *string*                                              | :heavy_check_mark:                                    | A unique identifier for the custom permission policy. |
| `AccountId`                                           | *string*                                              | :heavy_minus_sign:                                    | Account ID                                            |

### Response

**[CustomPolicyResponse](../../Models/Components/CustomPolicyResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Update

Update a specific custom policy by providing the entire policy entity in the request body. Ensure the new `policy_statement` includes modifications. Existing permissions will be replaced with the new data.

*Note:* Updating a policy with an identical `policy_statement` will trigger a 409 error.


### Example Usage: cedarErrorExample

<!-- UsageSnippet language="csharp" operationID="updateCustomPolicy" method="put" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="cedarErrorExample" -->
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

var res = await sdk.CustomPolicies.UpdateAsync(
    policyId: "<id>",
    updateCustomPolicy: new UpdateCustomPolicy() {
        PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
        ",
        Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
        ScopeType = ScopeTypeEnum.Prodenv,
        ScopeId = "975l29lz02jt0836fhwi",
        Name = "Read access to Clothing folder",
    }
);

// handle response
```
### Example Usage: invalidFieldErrorExample

<!-- UsageSnippet language="csharp" operationID="updateCustomPolicy" method="put" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="invalidFieldErrorExample" -->
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

var res = await sdk.CustomPolicies.UpdateAsync(
    policyId: "<id>",
    updateCustomPolicy: new UpdateCustomPolicy() {
        PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
        ",
        Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
        ScopeType = ScopeTypeEnum.Prodenv,
        ScopeId = "975l29lz02jt0836fhwi",
        Name = "Read access to Clothing folder",
    }
);

// handle response
```
### Example Usage: missingFieldsUpdateErrorExample

<!-- UsageSnippet language="csharp" operationID="updateCustomPolicy" method="put" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="missingFieldsUpdateErrorExample" -->
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

var res = await sdk.CustomPolicies.UpdateAsync(
    policyId: "<id>",
    updateCustomPolicy: new UpdateCustomPolicy() {
        PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
        ",
        Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
        ScopeType = ScopeTypeEnum.Prodenv,
        ScopeId = "975l29lz02jt0836fhwi",
        Name = "Read access to Clothing folder",
    }
);

// handle response
```
### Example Usage: updateCustomPolicyExample

<!-- UsageSnippet language="csharp" operationID="updateCustomPolicy" method="put" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="updateCustomPolicyExample" -->
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

var res = await sdk.CustomPolicies.UpdateAsync(
    policyId: "<id>",
    updateCustomPolicy: new UpdateCustomPolicy() {
        PolicyStatement = "permit(principal == Cloudinary::APIKey::\"1234\",action==Cloudinary::Action::\"read\",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\"asdfjkl12347890\")} ;",
        Description = "Permit read access to the Accessories folder with external ID asdfjkl12347890.",
        ScopeType = ScopeTypeEnum.Prodenv,
        ScopeId = "975l29lz02jt0836fhwi",
        Name = "Read access to Accessories folder",
    }
);

// handle response
```
### Example Usage: updatePolicyResponse

<!-- UsageSnippet language="csharp" operationID="updateCustomPolicy" method="put" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" example="updatePolicyResponse" -->
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

var res = await sdk.CustomPolicies.UpdateAsync(
    policyId: "<id>",
    updateCustomPolicy: new UpdateCustomPolicy() {
        PolicyStatement = @"permit(principal == Cloudinary::APIKey::\""1234\"",action==Cloudinary::Action::\""read\"",resource is Cloudinary::Folder ) when {resource.ancestor_ids.contains(\""asdfjkl12347890\"")} ;
        ",
        Description = "Permit read access to the Clothing folder with external ID asdfjkl12347890.",
        ScopeType = ScopeTypeEnum.Prodenv,
        ScopeId = "975l29lz02jt0836fhwi",
        Name = "Read access to Clothing folder",
    }
);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PolicyId`                                                          | *string*                                                            | :heavy_check_mark:                                                  | A unique identifier for the custom permission policy.               |
| `UpdateCustomPolicy`                                                | [UpdateCustomPolicy](../../Models/Components/UpdateCustomPolicy.md) | :heavy_check_mark:                                                  | Policy details                                                      |
| `AccountId`                                                         | *string*                                                            | :heavy_minus_sign:                                                  | Account ID                                                          |

### Response

**[CustomPolicyResponse](../../Models/Components/CustomPolicyResponse.md)**

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 400, 401, 403, 404, 409                                                | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 500                                                                    | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |

## Delete

Delete a specific custom policy.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="deleteCustomPolicy" method="delete" path="/v2/accounts/{account_id}/permissions/policies/custom/{policy_id}" -->
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

await sdk.CustomPolicies.DeleteAsync(policyId: "<id>");

// handle response
```

### Parameters

| Parameter                                             | Type                                                  | Required                                              | Description                                           |
| ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------------- |
| `PolicyId`                                            | *string*                                              | :heavy_check_mark:                                    | A unique identifier for the custom permission policy. |
| `AccountId`                                           | *string*                                              | :heavy_minus_sign:                                    | Account ID                                            |

### Errors

| Error Type                                                             | Status Code                                                            | Content Type                                                           |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Cloudinary.Account.Provisioning.Models.Errors.PermissionsErrorResponse | 401, 403, 404                                                          | application/json                                                       |
| Cloudinary.Account.Provisioning.Models.Errors.APIException             | 4XX, 5XX                                                               | \*/\*                                                                  |