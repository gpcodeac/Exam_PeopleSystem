using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.Database.Models
{
    public class PlaceOfResidence
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public int PersonalInformationId { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        
    }
}
