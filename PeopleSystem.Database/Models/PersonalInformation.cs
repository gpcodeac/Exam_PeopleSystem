using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.Database.Models
{
    internal class PersonalInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public ProfilePhoto? ProfilePhoto { get; set; }
        public PlaceOfResidence? PlaceOfResidence { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
