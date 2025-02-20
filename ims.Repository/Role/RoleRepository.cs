﻿using ims.Core.Repository;
using ims.Data.Context;
using ims.Data.Entity;
using ims.Data.EqualityComparer;
using ims.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Entity = ims.Data.Entity;

namespace ims.Repository.Role;

public class RoleRepository : Repository<Entity.Role>, IRoleRepository
{
    private AppDbContext dbContext { get => _context as AppDbContext; }

    public RoleRepository(DbContext context) : base(context)
    {
    }

    public async Task<Entity.Role> GetWithPermissionsByIdAsync(int id)
    {
        return await dbContext.Role.Include(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
    }

    public new void Update(Entity.Role entity)
    {
        entity.Permissions = dbContext.Permission.AsEnumerable().Intersect(entity.Permissions, new PermissionComparer()).ToList();
        dbContext.RolePermission.Where(x => x.RoleId == entity.Id).ExecuteDelete();
        dbContext.Role.Update(entity);
    }

}
