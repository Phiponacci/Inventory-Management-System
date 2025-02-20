﻿using System.Collections.Generic;

namespace ims.Data.Entity;

public class Role : BaseEntity
{
    public string RoleName { get; set; }

    public ICollection<Permission> Permissions { get; set; }

    public ICollection<User> Users { get; set; }
}
