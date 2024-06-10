using PeopleSystem.Database.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.Database.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateOnly DateOfBirth { get; set; }

        [StringLength(11)]
        public string PersonalIdentificationNumber { get; set; }

        [StringLength(12)]
        public string? PhoneNumber { get; set; }

        [StringLength(320)]
        public string? Email { get; set; }

        public ProfilePhoto? ProfilePhoto { get; set; }

        public PlaceOfResidence? PlaceOfResidence { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
