﻿using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;


namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserSignupRequestDto
    {
        [Required] //do not need them it seems, it is just enforced through the structure of the Dto
        [UsernameLength(3, 20)]
        public string Username { get; set; }

        [Required]
        [PasswordComplexity]
        public string Password { get; set; }
    }
}