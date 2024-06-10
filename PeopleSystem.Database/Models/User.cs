using PeopleSystem.Database.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.Database.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Username { get; set; }
    
        [MaxLength(300)]
        public byte[] PasswordHash { get; set; }

        [MaxLength(300)]
        public byte[] PasswordSalt { get; set; }

        public Role Role { get; set; }

        public virtual List<PersonalInformation>? PersonalInformation { get; set; }

    }
}
