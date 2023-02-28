using ims.Common.Extensions;
using ims.Data.Entity;

namespace ims.Data.Constants;

internal static class Users
{
    public static readonly User AdminUser = new()
    {
        Id = 1,
        UserName = "Admin",
        Password = "Admin$$123".HashPassword()
    };
}
