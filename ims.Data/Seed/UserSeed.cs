﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ims.Data.Entity;
using ims.Common.Extensions;

namespace ims.Data.Seed;

internal class UserSeed : IEntityTypeConfiguration<User>
{
    string adminPassword = "12345";
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User { Id = 1, UserName = "Admin", FirstName = "Admin", LastName = "Admin", PasswordHash = adminPassword.MD5Hash(), CreateDate = DateTime.Now });
    }
}
