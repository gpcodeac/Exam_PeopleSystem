using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class PlaceOfResidenceDto
    {
        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž ]+$")]
        public string City { get; set; }

        [MaxLength(100)]
        [RegularExpression(@"^(?:[A-Za-z0-9ĄČĘĖĮŠŲŪŽąčęėįšųūž]+(?:-|\.? )?)+$")]
        public string Street { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^[\d\w\-\/]+$")]
        public string HouseNumber { get; set; }

        [MaxLength(10)]
        [RegularExpression(@"^[\d\w\-\/]+$")]
        public string? ApartmentNumber { get; set; }

        [MaxLength(8)]
        [RegularExpression(@"^LT-\d{5}$")]
        public string? PostalCode { get; set; }
    }
}
