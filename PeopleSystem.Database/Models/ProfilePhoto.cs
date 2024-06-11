using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSystem.Database.Models
{
    [Index(nameof(PersonalInformationId), IsUnique = true)]
    public class ProfilePhoto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }

        [StringLength(255)]
        public string ThumbnailPath { get; set; }

        [ForeignKey("PersonalInformation")]
        public int PersonalInformationId { get; set; }

        public PersonalInformation PersonalInformation { get; set; }
    }
}
