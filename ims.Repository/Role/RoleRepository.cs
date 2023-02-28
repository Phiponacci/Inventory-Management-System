using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Entity = ims.Data.Entity;

namespace ims.Repository.Role;

public class RoleRepository : Repository<Entity.Role>, IRoleRepository
{
    private AppDbContext dbContext { get => _context as AppDbContext; }

    public RoleRepository(DbContext context) : base(context)
    {
    }
}
