# RoleAssignment

A role assignment with optional scope and policy parameters.


## Fields

| Field                                                           | Type                                                            | Required                                                        | Description                                                     | Example                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `Id`                                                            | *string*                                                        | :heavy_check_mark:                                              | The role ID.                                                    | media_library_admin                                             |
| `ScopeId`                                                       | *string*                                                        | :heavy_minus_sign:                                              | The scope (product environment) ID the role applies to.         |                                                                 |
| `PolicyParameters`                                              | [PolicyParameters](../../Models/Components/PolicyParameters.md) | :heavy_minus_sign:                                              | Optional content-scope policy parameters.                       |                                                                 |
| `AdditionalProperties`                                          | Dictionary<String, *object*>                                    | :heavy_minus_sign:                                              | N/A                                                             |                                                                 |