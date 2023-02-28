using ims.Security.ClaimTypes;
using System.Security.Claims;

namespace ims.Security.Extensions;

public static class UserPermissionExtensions
{
    public static bool HasPermission(this ClaimsPrincipal user, string module, string operation)
    {
        return user.HasClaim(c => c.Type == PermissionClaimType.Permission && c.Value == $"{PermissionClaimType.Permission}.{module}.{operation}");
    }
}
