using PeopleSystem.Database.Enums;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using PeopleSystem.BusinessLogic.Attributes;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class PersonalInformationDto
    {
        [Length(2,50)]
        public string FirstName { get; set; }

        [Length(2,50)]
        public string LastName { get; set; }
        
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        
        public DateOnly DateOfBirth { get; set; }

        [LithuanianPersonalNumber]
        public string PersonalIdentificationNumber { get; set; }


        ////validations
        //public string? PhoneNumber { get; set; }
        ////validations, unique check not needed because personal code is not unique in our situation either
        //public string? Email { get; set; }
        ////validations inside this other model/dto for file type and file size and minimum resolutions 
        //public ProfilePhoto? ProfilePhoto { get; set; }
        //public PlaceOfResidence? PlaceOfResidence { get; set; }
        //[JsonIgnore]
        public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}
