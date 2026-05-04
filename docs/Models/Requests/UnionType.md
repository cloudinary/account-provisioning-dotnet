# UnionType

Whether to return users who last logged in within the specified date range (include) or those who didn't
last log in within the range (exclude). **Possible values**: `include`, `exclude`. **Default**: `include`.


## Example Usage

```csharp
using Cloudinary.Account.Provisioning.Models.Requests;

var value = UnionType.Include;
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Include` | include   |
| `Exclude` | exclude   |