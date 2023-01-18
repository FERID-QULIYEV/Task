﻿using System.ComponentModel.DataAnnotations;
namespace Pronia.ViewModels.User
{
    public class UserRegisterVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required] 
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string CheckPassword { get; set; }

    }
}
