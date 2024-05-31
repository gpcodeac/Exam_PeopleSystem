using Microsoft.EntityFrameworkCore;
using PeopleSystem.Database.Models;

namespace PeopleSystem.Database
{
    public class AppDBContext: DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<PersonalInformation> PersonalInformations { get; set; }
        internal DbSet<PlaceOfResidence> PlacesOfResidence { get; set; }
        internal DbSet<ProfilePhoto> ProfilePhotos { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
