using PeopleSystem.Database.Enums;

namespace PeopleSystem.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public virtual PersonalInformation? PersonalInformation { get; set; }

    }
}
