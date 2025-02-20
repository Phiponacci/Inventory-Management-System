﻿using System.Collections.Generic;

namespace ims.Data.Entity;

public class User : BaseEntity
{ 
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public ICollection<Role> Roles { get; set; }
}
