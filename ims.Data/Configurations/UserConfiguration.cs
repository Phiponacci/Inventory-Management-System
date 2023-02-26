using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ims.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace ims.Data.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.FirstName).HasMaxLength(40);
        builder.Property(x => x.LastName).HasMaxLength(40);
        builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(40);
        builder.Property(x => x.UserName).IsRequired().HasMaxLength(40);
        builder.HasIndex(x => x.UserName).IsUnique();

        builder
            .Ignore(c => c.AccessFailedCount)
            .Ignore(c => c.LockoutEnabled)
            .Ignore(c => c.ConcurrencyStamp)
            .Ignore(c => c.LockoutEnd)
            .Ignore(c => c.EmailConfirmed)
            .Ignore(c => c.NormalizedEmail)
            .Ignore(c => c.NormalizedUserName)
            .Ignore(c => c.PhoneNumberConfirmed)
            .Ignore(c => c.TwoFactorEnabled);

        builder.ToTable("User");
    }
}
