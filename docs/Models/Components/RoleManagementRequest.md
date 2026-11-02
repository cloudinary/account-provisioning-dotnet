# RoleManagementRequest

A role management operation and the roles it applies to.


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Operation`                                                       | [Operation](../../Models/Components/Operation.md)                 | :heavy_check_mark:                                                | Whether to add or remove the listed roles.                        | add                                                               |
| `Roles`                                                           | List<[RoleAssignment](../../Models/Components/RoleAssignment.md)> | :heavy_check_mark:                                                | The roles to add or remove.                                       |                                                                   |