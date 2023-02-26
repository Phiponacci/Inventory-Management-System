using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ims.Core.Repository
{
    public interface IUserRepository : IRepository<ims.Data.Entity.User>
    {
        Task<bool> UserNameValidationCreateUser(string username);
        Task<bool> UserNameValidationUpdateUser(string username, int Id);
        Task<bool> Login(string userName, string password);
    }
}
