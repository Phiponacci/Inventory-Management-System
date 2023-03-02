using ims.Model.Domain;
using ims.Model.Service;
using System.Threading.Tasks;

namespace ims.Core.Service;

public interface IUserService : IService<UserDTO>
{
    ServiceResult<UserDTO> Login(string userName, string password);

    public Task<ServiceResult<UserDTO>> GetWithRolesById(int id);
    public Task<ServiceResult<UserDTO>> GetWithRolesByUsername(string username);
}