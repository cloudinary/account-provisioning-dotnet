# Cloudinary Account Provisioning .NET SDK

[![NuGet Version](https://img.shields.io/nuget/v/Cloudinary.Account.Provisioning.svg)](https://www.nuget.org/packages/Cloudinary.Account.Provisioning)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Cloudinary.Account.Provisioning.svg)](https://www.nuget.org/packages/Cloudinary.Account.Provisioning)
[![License](https://img.shields.io/github/license/cloudinary/account-provisioning-dotnet.svg)](https://github.com/cloudinary/account-provisioning-dotnet/blob/main/LICENSE)

Developer-friendly & type-safe C# SDK specifically catered to leverage the *Cloudinary Account Provisioning* API.

<!-- Start Summary [summary] -->
## Summary

Cloudinary Account Provisioning API: Accounts with provisioning API access can create and manage their **product environments**, **users** and **user groups** using the RESTful Provisioning API. 

Provisioning API access is available [upon request](https://cloudinary.com/contact?plan=enterprise) for accounts on an [Enterprise plan](https://cloudinary.com/pricing#pricing-enterprise).

The API uses **Basic Authentication** over HTTPS. Your **Account API Key** and **Account API Secret** (previously referred to as **Provisioning API keys**) are used for the authentication. These credentials (as well as your ACCOUNT_ID) are located in the [Cloudinary Console](https://console.cloudinary.com/pm) under **Settings > Account API Keys**.

The Provisioning API has dedicated SDKs for the following languages:

* [JavaScript](https://github.com/cloudinary/account-provisioning-js)
* [PHP](https://github.com/cloudinary/account-provisioning-php)
* [Java](https://github.com/cloudinary/account-provisioning-java)

Useful links:
* [Provisioning API reference (Classic)](https://cloudinary.com/documentation/provisioning_api_1) (includes SDKs for additional languages)

Accounts with Permissions API access can assign roles, made up of system policies, to control what principals (users, groups, and API keys) can do across the Cloudinary account and product environments. For more information about Cloudinary roles and permissions, see the [Role-based permissions](permissions_overview) guide.

Permissions API access is available [upon request](https://cloudinary.com/contact?plan=enterprise) for accounts on an [Enterprise plan](https://cloudinary.com/pricing#pricing-enterprise).

The API uses **Basic Authentication** over HTTPS. Your **Account API Key** and **Account API Secret** (previously referred to as **Provisioning API keys**) are used for the authentication. These credentials (as well as your ACCOUNT_ID) are located in the [Cloudinary Console](https://console.cloudinary.com/app/settings/account-api-keys) under **Settings > Account API Keys**.

_**Important:**_

_Cloudinary's **Roles and Permissions Management** is now available as a **Beta**. This is an early stage release, and while it's functional and ready for real-world testing, it's subject to change as we continue refining the experience based on what we learn, including your feedback.
During the Beta period, core functionality is considered stable, though some APIs, scopes, or response formats may evolve._

_**How you can help:**_

* _Use Roles and Permissions Management in real projects, prototypes, or tests._
* _Share feedback, issues, or ideas with our support team._

_Thank you for exploring this early release and helping us shape these tools to best meet your needs._
<!-- End Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [Cloudinary Account Provisioning .NET SDK](#cloudinary-account-provisioning-net-sdk)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Configuration](#configuration)
  * [Authentication](#authentication)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Global Parameters](#global-parameters)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Custom HTTP Client](#custom-http-client)
* [Development](#development)
  * [Maturity](#maturity)
  * [Contributions](#contributions)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Cloudinary.Account.Provisioning
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Cloudinary/Account/Provisioning/Cloudinary.Account.Provisioning.csproj
```
<!-- End SDK Installation [installation] -->

<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

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
<!-- End SDK Example Usage [usage] -->

## Configuration

### Environment Variables

The SDK loads credentials and configuration automatically from environment variables. The simplest way to configure the SDK is to set the `CLOUDINARY_ACCOUNT_URL` environment variable:

```bash
export CLOUDINARY_ACCOUNT_URL=account://<PROVISIONING_API_KEY>:<PROVISIONING_API_SECRET>@<ACCOUNT_ID>
```

This single URL provides all three required values. You can find these credentials in the [Cloudinary Console](https://console.cloudinary.com/pm) under **Settings > Account API Keys**.

Alternatively, you can set each value individually:

| Environment Variable                | Description              |
| ----------------------------------- | ------------------------ |
| `CLOUDINARY_ACCOUNT_URL`            | Account URL (recommended — provides all values below) |
| `CLOUDINARY_PROVISIONING_API_KEY`   | Account API Key          |
| `CLOUDINARY_PROVISIONING_API_SECRET`| Account API Secret       |
| `CLOUDINARY_ACCOUNT_ID`             | Account ID               |

Individual environment variables take precedence over values parsed from `CLOUDINARY_ACCOUNT_URL`.

### Usage with Environment Variables

When environment variables are set:

```csharp
using Cloudinary.Account.Provisioning;

var sdk = new CldProvisioning(new SDKConfig(client: null));

var result = await sdk.ProductEnvironments.ListAsync();
```

### Explicit Configuration

You can also pass credentials directly:

```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;

var sdk = new CldProvisioning(
    security: new Security()
    {
        ProvisioningApiKey = "YOUR_API_KEY",
        ProvisioningApiSecret = "YOUR_API_SECRET",
    },
    accountId: "YOUR_ACCOUNT_ID"
);
```

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name                                             | Type | Scheme      | Environment Variable                                                       |
| ------------------------------------------------ | ---- | ----------- | -------------------------------------------------------------------------- |
| `ProvisioningApiKey`<br/>`ProvisioningApiSecret` | http | Custom HTTP | `CLOUDINARY_PROVISIONING_API_KEY`<br/>`CLOUDINARY_PROVISIONING_API_SECRET` |

You can set the security parameters through the `security` optional parameter when initializing the SDK client instance. For example:
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;

var sdk = new CldProvisioning(
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    },
    accountId: "<id>"
);

GetProductEnvironmentsRequest req = new GetProductEnvironmentsRequest() {
    Enabled = true,
    Prefix = "product",
};

var res = await sdk.ProductEnvironments.ListAsync(req);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

### [AccessKeys](docs/sdks/accesskeys/README.md)

* [List](docs/sdks/accesskeys/README.md#list) - Get access keys
* [Generate](docs/sdks/accesskeys/README.md#generate) - Generate an access key
* [DeleteByName](docs/sdks/accesskeys/README.md#deletebyname) - Delete access key by name
* [Update](docs/sdks/accesskeys/README.md#update) - Update an access key
* [Delete](docs/sdks/accesskeys/README.md#delete) - Delete access key

### [BillingUsage](docs/sdks/billingusage/README.md)

* [Get](docs/sdks/billingusage/README.md#get) - Get billing usage information

### [CustomPolicies](docs/sdks/custompolicies/README.md)

* [List](docs/sdks/custompolicies/README.md#list) - Get custom policies
* [Create](docs/sdks/custompolicies/README.md#create) - Create custom policy
* [Get](docs/sdks/custompolicies/README.md#get) - Get custom policy
* [Update](docs/sdks/custompolicies/README.md#update) - Update custom policy
* [Delete](docs/sdks/custompolicies/README.md#delete) - Delete custom policy

### [EffectivePolicies](docs/sdks/effectivepolicies/README.md)

* [List](docs/sdks/effectivepolicies/README.md#list) - Get effective policies

### [Principals](docs/sdks/principals/README.md)

* [ListRoles](docs/sdks/principals/README.md#listroles) - Get a principal's roles
* [UpdateRoles](docs/sdks/principals/README.md#updateroles) - Assign roles to a principal
* [Inspect](docs/sdks/principals/README.md#inspect) - Inspect
* [InspectMultiple](docs/sdks/principals/README.md#inspectmultiple) - Inspect multiple

### [ProductEnvironments](docs/sdks/productenvironments/README.md)

* [List](docs/sdks/productenvironments/README.md#list) - Get product environments
* [Create](docs/sdks/productenvironments/README.md#create) - Create product environment
* [Get](docs/sdks/productenvironments/README.md#get) - Get product environment
* [Update](docs/sdks/productenvironments/README.md#update) - Update product environment
* [Delete](docs/sdks/productenvironments/README.md#delete) - Delete product environment

### [Public](docs/sdks/public/README.md)

* [GetCatalog](docs/sdks/public/README.md#getcatalog) - Get system roles and policies catalog
* [ValidatePolicy](docs/sdks/public/README.md#validatepolicy) - Validate a Cedar policy
* [GetSchema](docs/sdks/public/README.md#getschema) - Get Cedar schema

### [Roles](docs/sdks/roles/README.md)

* [List](docs/sdks/roles/README.md#list) - Get roles
* [Create](docs/sdks/roles/README.md#create) - Create custom role
* [Get](docs/sdks/roles/README.md#get) - Get role
* [Update](docs/sdks/roles/README.md#update) - Update custom role
* [Delete](docs/sdks/roles/README.md#delete) - Delete custom role
* [ListPrincipals](docs/sdks/roles/README.md#listprincipals) - Get a role's principals
* [UpdatePrincipals](docs/sdks/roles/README.md#updateprincipals) - Assign principals to a role

### [SystemPolicies](docs/sdks/systempolicies/README.md)

* [List](docs/sdks/systempolicies/README.md#list) - Get system policies

### [UserGroups](docs/sdks/usergroups/README.md)

* [List](docs/sdks/usergroups/README.md#list) - Get User Groups
* [Create](docs/sdks/usergroups/README.md#create) - Create User Group
* [Get](docs/sdks/usergroups/README.md#get) - Get User Group
* [Update](docs/sdks/usergroups/README.md#update) - Update User Group
* [Delete](docs/sdks/usergroups/README.md#delete) - Delete User Group
* [ListUsers](docs/sdks/usergroups/README.md#listusers) - Get Users in User Group
* [AddUser](docs/sdks/usergroups/README.md#adduser) - Add User to User Group
* [RemoveUser](docs/sdks/usergroups/README.md#removeuser) - Remove User from User Group

### [Users](docs/sdks/users/README.md)

* [List](docs/sdks/users/README.md#list) - Get users
* [Create](docs/sdks/users/README.md#create) - Create user
* [Get](docs/sdks/users/README.md#get) - Get user
* [Update](docs/sdks/users/README.md#update) - Update user
* [Delete](docs/sdks/users/README.md#delete) - Delete user
* [GetGroups](docs/sdks/users/README.md#getgroups) - Get user groups
* [ListSubAccounts](docs/sdks/users/README.md#listsubaccounts) - Get user sub-accounts

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Global Parameters [global-parameters] -->
## Global Parameters

A parameter is configured globally. This parameter may be set on the SDK client instance itself during initialization. When configured as an option during SDK initialization, This global value will be used as the default on the operations that use it. When such operations are called, there is a place in each to override the global value, if needed.

For example, you can set `account_id` to `"<id>"` at SDK initialization and then you do not have to pass the same value on calls to operations like `List`. But if you want to do so you may, which will locally override the global setting. See the example code below for a demonstration.


### Available Globals

The following global parameter is available.
Global parameters can also be set via environment variable.

| Name      | Type   | Description | Environment           |
| --------- | ------ | ----------- | --------------------- |
| accountId | string | Account ID  | CLOUDINARY_ACCOUNT_ID |

### Example

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
<!-- End Global Parameters [global-parameters] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`CldProvisioningException`](./src/Cloudinary/Account/Provisioning/Models/Errors/CldProvisioningException.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `StatusCode`  | *int*                 | HTTP status code      |
| `Headers`     | *HttpResponseHeaders* | HTTP headers          |
| `ContentType` | *string?*             | HTTP content type     |
| `RawResponse` | *HttpResponseMessage* | HTTP response object  |
| `Body`        | *string*              | HTTP response body    |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Errors;
using Cloudinary.Account.Provisioning.Models.Requests;

var sdk = new CldProvisioning(
    accountId: "<id>",
    security: new Security() {
        ProvisioningApiKey = "CLOUDINARY_PROVISIONING_API_KEY",
        ProvisioningApiSecret = "CLOUDINARY_PROVISIONING_API_SECRET",
    }
);

try
{
    GetProductEnvironmentsRequest req = new GetProductEnvironmentsRequest() {
        Enabled = true,
        Prefix = "product",
    };

    var res = await sdk.ProductEnvironments.ListAsync(req);

    // handle response
}
catch (CldProvisioningException ex) // all SDK exceptions inherit from CldProvisioningException
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpResponseMessage rawResponse = ex.RawResponse;
    HttpResponseHeaders headers = ex.Headers;
    int statusCode = ex.StatusCode;
    string? contentType = ex.ContentType;
    var responseBody = ex.Body;

    if (ex is ErrorResponse) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        ErrorResponsePayload payload = ex.Payload;
        Error Error = payload.Error;
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (OperationCanceledException ex)
{
    // CancellationToken was cancelled
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exception:**
* [`CldProvisioningException`](./src/Cloudinary/Account/Provisioning/Models/Errors/CldProvisioningException.cs): The base class for HTTP error responses.

<details><summary>Less common exceptions (4)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`CldProvisioningException`](./src/Cloudinary/Account/Provisioning/Models/Errors/CldProvisioningException.cs):
  * [`ErrorResponse`](./src/Cloudinary/Account/Provisioning/Models/Errors/ErrorResponse.cs): Bad request. Applicable to 26 of 47 methods.*
  * [`PermissionsErrorResponse`](./src/Cloudinary/Account/Provisioning/Models/Errors/PermissionsErrorResponse.cs): Applicable to 18 of 47 methods.*
  * [`ResponseValidationError`](./src/Cloudinary/Account/Provisioning/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Index

You can override the default server globally by passing a server index to the `serverIndex: int` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the indexes associated with the available servers:

| #   | Server                            | Variables | Description                                     |
| --- | --------------------------------- | --------- | ----------------------------------------------- |
| 0   | `https://{region}.cloudinary.com` | `region`  | Regional API endpoints for optimal performance. |
| 1   | `https://{host}`                  | `host`    | Custom domains for enterprise deployments.      |

If the selected server has variables, you may override its default values through the additional parameters made available in the SDK constructor:

| Variable | Parameter                                                     | Supported Values                            | Default                | Description                 |
| -------- | ------------------------------------------------------------- | ------------------------------------------- | ---------------------- | --------------------------- |
| `region` | `region: Cloudinary.Account.Provisioning.Models.ServerRegion` | - `"api"`<br/>- `"api-eu"`<br/>- `"api-ap"` | `"api"`                | Regional endpoint selection |
| `host`   | `host: string`                                                | string                                      | `"api.cloudinary.com"` | API host domain.            |

#### Example

```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;

var sdk = new CldProvisioning(
    serverIndex: 0,
    region: "api-ap",
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

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Models.Components;
using Cloudinary.Account.Provisioning.Models.Requests;

var sdk = new CldProvisioning(
    serverUrl: "https://api.cloudinary.com",
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
<!-- End Server Selection [server] -->

<!-- Start Custom HTTP Client [http-client] -->
## Custom HTTP Client

The C# SDK makes API calls using an `ISpeakeasyHttpClient` that wraps the native
[HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient). This
client provides the ability to attach hooks around the request lifecycle that can be used to modify the request or handle
errors and response.

The `ISpeakeasyHttpClient` interface allows you to either use the default `SpeakeasyHttpClient` that comes with the SDK,
or provide your own custom implementation with customized configuration such as custom message handlers, timeouts,
connection pooling, and other HTTP client settings.

The following example shows how to create a custom HTTP client with request modification and error handling:

```csharp
using Cloudinary.Account.Provisioning;
using Cloudinary.Account.Provisioning.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Create a custom HTTP client
public class CustomHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _defaultClient;

    public CustomHttpClient()
    {
        _defaultClient = new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Add custom header and timeout
        request.Headers.Add("x-custom-header", "custom value");
        request.Headers.Add("x-request-timeout", "30");
        
        try
        {
            var response = await _defaultClient.SendAsync(request, cancellationToken);
            // Log successful response
            Console.WriteLine($"Request successful: {response.StatusCode}");
            return response;
        }
        catch (Exception error)
        {
            // Log error
            Console.WriteLine($"Request failed: {error.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _defaultClient?.Dispose();
    }
}

// Use the custom HTTP client with the SDK
var customHttpClient = new CustomHttpClient();
var sdk = new CldProvisioning(client: customHttpClient);
```

<details>
<summary>You can also provide a completely custom HTTP client with your own configuration:</summary>

```csharp
using Cloudinary.Account.Provisioning.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Custom HTTP client with custom configuration
public class AdvancedHttpClient : ISpeakeasyHttpClient
{
    private readonly HttpClient _httpClient;

    public AdvancedHttpClient()
    {
        var handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 10,
            // ServerCertificateCustomValidationCallback = customCertValidation, // Custom SSL validation if needed
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        return await _httpClient.SendAsync(request, cancellationToken ?? CancellationToken.None);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

var sdk = CldProvisioning.Builder()
    .WithClient(new AdvancedHttpClient())
    .Build();
```
</details>

<details>
<summary>For simple debugging, you can enable request/response logging by implementing a custom client:</summary>

```csharp
public class LoggingHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _innerClient;

    public LoggingHttpClient(ISpeakeasyHttpClient innerClient = null)
    {
        _innerClient = innerClient ?? new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Log request
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        
        var response = await _innerClient.SendAsync(request, cancellationToken);
        
        // Log response
        Console.WriteLine($"Received {response.StatusCode} response");
        
        return response;
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new CldProvisioning(client: new LoggingHttpClient());
```
</details>

The SDK also provides built-in hook support through the `SDKConfiguration.Hooks` system, which automatically handles
`BeforeRequestAsync`, `AfterSuccessAsync`, and `AfterErrorAsync` hooks for advanced request lifecycle management.
<!-- End Custom HTTP Client [http-client] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development

## Maturity

This SDK is in beta, and there may be breaking changes between versions without a major version update. Therefore, we recommend pinning usage
to a specific package version. This way, you can install the same version each time without breaking changes unless you are intentionally
looking for the latest version.

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation. 
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release. 

### SDK Created by [Speakeasy](https://www.speakeasy.com/?utm_source=cloudinary-account-provisioning&utm_campaign=csharp)
