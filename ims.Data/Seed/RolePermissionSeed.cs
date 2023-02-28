using ims.Data.Constants;
using ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ims.Data.Seed;

internal class RolePermissionSeed : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasData(RolePermissions.AdminPermissions);
    }
}
