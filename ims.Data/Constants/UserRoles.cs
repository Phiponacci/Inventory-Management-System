using ims.Data.Entity;

namespace ims.Data.Constants;

public static class UserRoles
{
    public static readonly UserRole AdminRole = new UserRole { RoleId = Roles.AdminRole.Id, UserId = Users.AdminUser.Id };
}
