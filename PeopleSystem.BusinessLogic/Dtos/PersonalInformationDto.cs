using PeopleSystem.BusinessLogic.Attributes;
using PeopleSystem.Database.Enums;
using System.ComponentModel.DataAnnotations;

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

        [LithuanianPhoneNumber]
        public string? PhoneNumber { get; set; }

        //unique check not needed because personal code is not unique in our situation either
        [ValidEmailPattern]
        public string? Email { get; set; }

        public PlaceOfResidenceDto? PlaceOfResidence { get; set; }
    }
}
