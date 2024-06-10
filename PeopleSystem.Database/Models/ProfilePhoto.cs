using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        public int PersonalInformationId { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
