using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PeopleSystem.Database.Repositories;
using PeopleSystem.Database.Repositories.Interfaces;

namespace PeopleSystem.Database.Extensions
{
    public static class ServiceExtensions 
    {
        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IPlaceOfResidenceRepository, PlaceOfResidenceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
