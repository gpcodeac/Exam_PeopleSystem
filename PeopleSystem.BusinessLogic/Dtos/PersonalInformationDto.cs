using PeopleSystem.Database.Enums;
using PeopleSystem.Database.Models;
using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class PersonalInformationDto
    {
        //name validation
        public string FirstName { get; set; }
        //name validation
        public string LastName { get; set; }
        //OK, this is enforced via type
        public Gender Gender { get; set; }
        //should this validity be checked when parsing, it wont be able to parse if date is not valid isnt it?
        public DateOnly DateOfBirth { get; set; }



        ////validations
        //public string PersonalIdentificationNumber { get; set; }
        ////validations
        //public string? PhoneNumber { get; set; }
        ////validations, unique check not needed because personal code is not unique in our situation either
        //public string? Email { get; set; }
        ////validations inside this other model/dto for file type and file size and minimum resolutions 
        //public ProfilePhoto? ProfilePhoto { get; set; }
        //public PlaceOfResidence? PlaceOfResidence { get; set; }
        public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
