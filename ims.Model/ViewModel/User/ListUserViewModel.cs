using System;
using System.Collections.Generic;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.User
{
    public class ListUserViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
