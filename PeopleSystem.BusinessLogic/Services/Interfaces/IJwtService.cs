using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    internal interface IJwtService
    {
        string GenerateToken(User user);
    }
}