using Microsoft.EntityFrameworkCore;

namespace PeopleSystem.Database
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
    }
}
