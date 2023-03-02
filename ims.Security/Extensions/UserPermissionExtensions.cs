using ims.Security.ClaimTypes;
using ims.Security.Enums;
using System.Security.Claims;

namespace ims.Security.Extensions;

public static class UserPermissionExtensions
{
    public static bool HasPermission(this ClaimsPrincipal user, string module, string operation)
    {
        return user.HasClaim(PermissionClaimType.Permission, $"{PermissionClaimType.Permission}.{module}.{operation}");
    }

    public static bool HasFullAccessTo(this ClaimsPrincipal user, string module)
    {
        return Operation.GetValues().All(operation => user.HasPermission(module, operation));
    }
}
