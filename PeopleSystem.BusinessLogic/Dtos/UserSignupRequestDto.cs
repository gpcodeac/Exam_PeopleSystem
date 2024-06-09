using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;


namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserSignupRequestDto
    {
        [Required] //do not need the Required attribute, it seems, it is just enforced through the structure of the Dto
        //[UsernameLength(3, 20)]
        [Length(3,20)]
        public string Username { get; set; }

        [Required]
        [PasswordComplexity]
        public string Password { get; set; }
    }
}
