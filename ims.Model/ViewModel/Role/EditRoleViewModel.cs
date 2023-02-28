﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ims.Model.ViewModel.Base;

namespace ims.Model.ViewModel.Role;

public class EditRoleViewModel : BaseViewModel
{
    [Required]
    [MaxLength(50)]
    [Display]
    public string Name { get; set; }
}
