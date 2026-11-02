# ~~Role~~

The legacy role to assign. Deprecated: use `roles` (create) or `role_management` (update) instead. Can't be combined with `roles` or `role_management`.

> :warning: **DEPRECATED**: Use `roles` (create) or `role_management` (update) instead..

## Example Usage

```csharp
using Cloudinary.Account.Provisioning.Models.Requests;

var value = Role.MasterAdmin;
```


## Values

| Name                | Value               |
| ------------------- | ------------------- |
| `MasterAdmin`       | master_admin        |
| `Admin`             | admin               |
| `Billing`           | billing             |
| `TechnicalAdmin`    | technical_admin     |
| `Reports`           | reports             |
| `MediaLibraryAdmin` | media_library_admin |
| `MediaLibraryUser`  | media_library_user  |