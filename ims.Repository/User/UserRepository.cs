using ims.Core.Repository;
using ims.Data.Context;
using ims.Data.EqualityComparer;
using ims.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Entity = ims.Data.Entity;

namespace ims.Repository.User;

public class UserRepository : Repository<ims.Data.Entity.User>, IUserRepository
{
    private AppDbContext dbContext { get => _context as AppDbContext; }

    public UserRepository(DbContext context) : base(context)
    {
    }

    public new void Update(Entity.User entity)
    {
        entity.Roles = dbContext.Role.AsEnumerable().Intersect(entity.Roles, new IdComparer<Entity.Role>()).ToList();
        dbContext.UserRole.Where(x => x.UserId == entity.Id).ExecuteDelete();
        dbContext.User.Update(entity);
    }

    public async Task<bool> UserNameValidationCreateUser(string username)
    {
        return await dbContext.User.AnyAsync(x => x.UserName == username);
    }

    public async Task<bool> UserNameValidationUpdateUser(string username, int Id)
    {
        return await dbContext.User.AnyAsync(x => x.UserName == username && x.Id != Id);
    }
    public Entity.User Login(string username, string password)
    {
        return dbContext.User.Include(user => user.Roles).ThenInclude(roles => roles.Permissions).FirstOrDefault(x => x.UserName == username && x.Password == password);
    }

    public async Task<Entity.User> GetWithRolesByIdAsync(int id)
    {
        return await dbContext.User.Include(user => user.Roles).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Entity.User> GetWithRolesByUsernameAsync(string username)
    {
        return await dbContext.User.Include(user => user.Roles).FirstOrDefaultAsync(x => x.UserName == username);
    }
}
