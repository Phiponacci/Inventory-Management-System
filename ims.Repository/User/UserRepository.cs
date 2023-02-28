using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ims.Core.Repository;
using ims.Data.Context;
using ims.Repository.Base;
using Entity = ims.Data.Entity;

namespace ims.Repository.User;

public class UserRepository : Repository<ims.Data.Entity.User>, IUserRepository
{
    private AppDbContext dbContext { get => _context as AppDbContext; }

    public UserRepository(DbContext context) : base(context)
    {
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
}
