using System.ComponentModel.DataAnnotations;

namespace PeopleSystem.BusinessLogic.Dtos
{
    public class PlaceOfResidenceDto
    {
        [RegularExpression(@"^[A-Za-zĄČĘĖĮŠŲŪŽąčęėįšųūž ]+$")]
        public string City { get; set; }

        [RegularExpression(@"^(?:[A-Za-z0-9ĄČĘĖĮŠŲŪŽąčęėįšųūž]+(?:-|\.? )?)+$")]
        public string Street { get; set; }

        [RegularExpression(@"^[\d\w\-\/]+$")]
        public string HouseNumber { get; set; }

        [RegularExpression(@"^[\d\w\-\/]+$")]
        public string? ApartmentNumber { get; set; }

        [RegularExpression(@"^LT-\d{5}$")]
        public string? PostalCode { get; set; }

        //^([ĄČĘĖĮŠŲŪŽąčęėįšųūž\w]+[-. ]*)+$

        //^([A-Za-z0-9ĄČĘĖĮŠŲŪŽąčęėįšųūž]+(-|\.? )?)+$

        //^(?:[A-Za-z0-9ĄČĘĖĮŠŲŪŽąčęėįšųūž]+(?:-|\.? )?)+$

        //^(([ĄČĘĖĮŠŲŪŽąčęėįšųūž\w]+)[-. ]*)+$

    }
}
