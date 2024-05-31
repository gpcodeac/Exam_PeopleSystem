using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSystem.Database.Models
{
    internal class ProfilePhoto
    {
        public int Id { get; set; }
        public string ProfilePhotoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public int PersonalInformationId { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}
