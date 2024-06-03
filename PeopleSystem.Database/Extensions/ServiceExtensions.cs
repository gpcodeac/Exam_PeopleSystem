using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleSystem.Database.Repositories;
using PeopleSystem.Database.Repositories.Interfaces;

namespace PeopleSystem.Database.Extensions
{
    public static class ServiceExtensions 
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));
            services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
            services.AddScoped<IPlaceOfResidenceRepository, PlaceOfResidenceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
