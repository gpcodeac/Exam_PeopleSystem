using System.ComponentModel.DataAnnotations;


namespace PeopleSystem.BusinessLogic.Dtos
{
    public class UserRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
