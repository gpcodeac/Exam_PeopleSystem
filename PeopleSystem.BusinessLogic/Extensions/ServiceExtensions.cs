using Microsoft.Extensions.DependencyInjection;
using PeopleSystem.BusinessLogic.Mappings;
using PeopleSystem.BusinessLogic.Services;
using PeopleSystem.BusinessLogic.Services.Interfaces;

namespace PeopleSystem.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonalInformationService, PersonalInformationService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
