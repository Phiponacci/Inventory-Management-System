using ims.Model.ViewModel.Base;
using ims.Model.ViewModel.Permission;
using Microsoft.Extensions.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ims.Model.ViewModel.Role;

public class EditRoleViewModel : BaseViewModel
{
    [Required]
    [MaxLength(50)]
    [Display]
    public string RoleName { get; set; }

    public ICollection<PermissionViewModel> Permissions { get; set; }
}
