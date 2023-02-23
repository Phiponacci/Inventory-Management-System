using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

using ims.Data.Entity;

namespace ims.Data.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { Id = 1, ProductName = "Example Product", Barcode = "EX01", CreateDate = DateTime.Now, UnitOfMeasureId = 1, Price = 1 });
        }
    }
}
