﻿using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;


namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
