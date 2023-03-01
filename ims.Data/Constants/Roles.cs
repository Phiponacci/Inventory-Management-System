using ims.Data.Entity;
using ims.Security.Enums;

namespace ims.Data.Constants;

internal static class Roles
{
    public static readonly Entity.Role AdminRole = new()
    {
        Id = 1,
        RoleName = Security.Enums.Role.Admin
    };

    public static readonly Entity.Role AccountantRole = new()
    {
        Id = 2,
        RoleName = Security.Enums.Role.Accountant
    };

    public static readonly Entity.Role DriverRole = new()
    {
        Id = 3,
        RoleName = Security.Enums.Role.Driver
    };
}
