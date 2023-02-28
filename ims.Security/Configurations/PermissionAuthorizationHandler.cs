using Microsoft.AspNetCore.Authorization;

namespace ims.Security.Configurations;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    public PermissionAuthorizationHandler()
    {
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        if (context.User == null)
        {
            return;
        }
        var permissionss = context.User.Claims.Where(x => x.Type == "Permission" &&
                                                        x.Value == requirement.Permission);
        if (permissionss.Any())
        {
            context.Succeed(requirement);
        }
    }
}
