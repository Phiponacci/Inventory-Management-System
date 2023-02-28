using ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ims.Data.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(40);
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.Property(x => x.FirstName).HasMaxLength(40);
        builder.Property(x => x.LastName).HasMaxLength(40);
        builder.Property(x => x.Password).IsRequired();

        builder.HasMany(x => x.Roles).WithMany(x => x.Users).UsingEntity<UserRole>();

        builder.ToTable(nameof(User));
    }
}
