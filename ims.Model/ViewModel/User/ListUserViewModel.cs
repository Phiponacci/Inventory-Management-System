using System;
using System.Collections.Generic;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.User
{
    public class ListUserViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
