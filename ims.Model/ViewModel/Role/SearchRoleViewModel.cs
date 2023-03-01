using ims.Model.ViewModel.Base;
using System.ComponentModel.DataAnnotations;

namespace ims.Model.ViewModel.Role;

public class SearchRoleViewModel : BaseViewModel
{

    [Display(Name = "Role Name")]
    public string RoleName { get; set; }
}
