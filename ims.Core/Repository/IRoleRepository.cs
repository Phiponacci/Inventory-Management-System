using ims.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ims.Core.Repository;

public interface IRoleRepository : IRepository<Role>
{
    public Task<Role> GetWithPermissionsByIdAsync(int id);

    public void Update(Role entity);
}
