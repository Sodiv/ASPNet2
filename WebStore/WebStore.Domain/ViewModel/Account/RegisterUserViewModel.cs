﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Domain.ViewModel.Account
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
