using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.Role;

public class SearchRoleViewModel : BaseViewModel
{

    [Display]
    public string Name { get; set; }
}
