using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSystem.Database.Models
{
    [Index(nameof(PersonalInformationId), IsUnique = true)]
    public class PlaceOfResidence
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(10)]
        public string HouseNumber { get; set; }

        [StringLength(10)]
        public string? ApartmentNumber { get; set; }

        [StringLength(8)]
        public string? PostalCode { get; set; }

        [ForeignKey("PersonalInformation")]
        public int PersonalInformationId { get; set; }

        public PersonalInformation PersonalInformation { get; set; }
        
    }
}
