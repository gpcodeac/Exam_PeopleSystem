using PeopleSystem.Database.Enums;

namespace PeopleSystem.Database.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public Role Role { get; set; }
        public PersonalInformation PersonalInformation { get; set; }

    }
}
