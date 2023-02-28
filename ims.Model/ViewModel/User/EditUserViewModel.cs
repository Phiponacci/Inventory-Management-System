using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.User;

public class EditUserViewModel : BaseViewModel
{
    [MaxLength(50)]
    [Display]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(50)]
    [Display]
    public string UserName { get; set; }


    [MaxLength(18)]
    [Display]
    public string Password { get; set; }

    [MaxLength(30)]
    [Display]
    public string FirstName { get; set; }

    [MaxLength(30)]
    [Display]
    public string LastName { get; set; }

    [MaxLength(30)]
    [Display]
    public string PhoneNumber { get; set; }

}
