using ims.Model.Domain;
using ims.Model.Service;

namespace ims.Core.Service
{
    public interface IUserService : IService<UserDTO>
    {
        ServiceResult<UserDTO> Login(string userName, string password);
    }
}
