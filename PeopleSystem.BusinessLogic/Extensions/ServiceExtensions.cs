using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PeopleSystem.BusinessLogic.Services;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.BusinessLogic.Mappings;

namespace PeopleSystem.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
