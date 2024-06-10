using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(02)]
        public string? ApartmentNumber { get; set; }

        [StringLength(8)]
        public string? PostalCode { get; set; }

        public int PersonalInformationId { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; }
        
    }
}
