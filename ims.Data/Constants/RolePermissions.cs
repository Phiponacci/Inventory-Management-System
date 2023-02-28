using ims.Common.Enums;
using ims.Data.Entity;
using ims.Security;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ims.Data.Constants;

public static class RolePermissions
{
    public static readonly List<RolePermission> AdminPermissions = Permissions.AllPermissions.Select(p => new RolePermission
    {
        RoleId = Roles.AdminRole.Id,
        PermissionId = p.Id
    }).ToList();
}
