using ims.Data.Entity;
using System.Threading.Tasks;

namespace ims.Core.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserNameValidationCreateUser(string username);
        Task<bool> UserNameValidationUpdateUser(string username, int Id);
        User Login(string username, string password);

        Task<User> GetWithRolesByIdAsync(int id);
        Task<User> GetWithRolesByUsernameAsync(string username);
    }
}
