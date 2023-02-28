using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ims.Data.Entity;

namespace ims.Data.Configurations;

internal class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.StoreName).IsRequired().HasMaxLength(30);
        builder.Property(x => x.StoreCode).IsRequired().HasMaxLength(10);    
        builder.ToTable(nameof(Store));
    }
}
