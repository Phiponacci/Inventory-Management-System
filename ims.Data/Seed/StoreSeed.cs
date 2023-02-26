﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Data.Entity;

namespace ims.Data.Seed;

internal class StoreSeed : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasData(new Store { Id = 1, StoreCode = "EX01", StoreName = "Example Store", CreateDate = DateTime.Now });
    }
}
