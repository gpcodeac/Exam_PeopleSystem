using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Services
{
    internal class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService()
        {
        }

        public string GenerateToken(User user)
        {
            return "";
        }
    }
}
