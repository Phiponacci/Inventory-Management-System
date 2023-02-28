using ims.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ims.Data.Configurations;

internal class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.UnitOfMeasureName).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Isocode).IsRequired().HasMaxLength(3);
        builder.ToTable(nameof(UnitOfMeasure));
    }
}
