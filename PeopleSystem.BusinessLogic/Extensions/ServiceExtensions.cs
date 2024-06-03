using Microsoft.Extensions.DependencyInjection;
using PeopleSystem.BusinessLogic.Services;
using PeopleSystem.BusinessLogic.Services.Interfaces;

namespace PeopleSystem.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
