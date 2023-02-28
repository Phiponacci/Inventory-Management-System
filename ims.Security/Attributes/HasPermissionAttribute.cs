using ims.Security.ClaimTypes;
using Microsoft.AspNetCore.Authorization;


namespace ims.Security.Attributes;

public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string module, string operation) : base(policy: $"{PermissionClaimType.Permission}.{module}.{operation}")
    {
    }
}
