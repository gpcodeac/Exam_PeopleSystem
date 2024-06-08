using PeopleSystem.Database.Enums;  

namespace PeopleSystem.Database.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
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
