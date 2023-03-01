using System.Collections.Generic;

namespace ims.Model.Domain;

public class RoleDTO : BaseDTO
{
    public string RoleName { get; set; }
    public ICollection<PermissionDTO> Permissions { get; set; }
}
