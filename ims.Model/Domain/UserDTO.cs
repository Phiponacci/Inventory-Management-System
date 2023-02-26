using System;
using System.Collections.Generic;
using System.Text;

namespace ims.Model.Domain
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
