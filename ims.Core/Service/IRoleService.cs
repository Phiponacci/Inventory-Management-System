using ims.Model.Domain;
using ims.Model.Service;
using System.Threading.Tasks;

namespace ims.Core.Service
{
    public interface IRoleService : IService<RoleDTO>
    {
        public Task<ServiceResult<RoleDTO>> GetWithPermissionsByIdAsync(int id);
    }
}
