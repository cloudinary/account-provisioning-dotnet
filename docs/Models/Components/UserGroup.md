# UserGroup

User group.


## Fields

| Field                                                                                 | Type                                                                                  | Required                                                                              | Description                                                                           |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `Id`                                                                                  | *string*                                                                              | :heavy_minus_sign:                                                                    | The user group's ID.                                                                  |
| `Name`                                                                                | *string*                                                                              | :heavy_minus_sign:                                                                    | The user group's name.                                                                |
| `Users`                                                                               | List<[UserGroupUser](../../Models/Components/UserGroupUser.md)>                       | :heavy_minus_sign:                                                                    | A list of user group users.<br/>Only returned in extended_details.<br/>               |
| `CreatedAt`                                                                           | [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0) | :heavy_minus_sign:                                                                    | The date when the user group was created.<br/>Only returned in extended_details.<br/> |
| `UpdatedAt`                                                                           | [DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0) | :heavy_minus_sign:                                                                    | The date when the user group was last updated.<br/>Only returned in extended_details.<br/> |