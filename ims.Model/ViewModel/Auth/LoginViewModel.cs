using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.Auth
{
    public class LoginViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display]
        public string UserName { get; set; }

        [Required]
        [MaxLength(18)]
        [Display]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
