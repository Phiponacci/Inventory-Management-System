using ims.Data.Constants;
using ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using Security = ims.Security;


namespace ims.Data.Seed;

internal class RoleSeed : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData(Roles.AdminRole, Roles.AccountantRole, Roles.DriverRole);
    }
}
