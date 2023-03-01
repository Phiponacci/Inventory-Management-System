using ims.Data.Entity;
using System.Threading.Tasks;

namespace ims.Core.Repository;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role> GetWithPermissionsByIdAsync(int id);

    public new void Update(Role entity);
}
