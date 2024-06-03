using PeopleSystem.Database.Models;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        User ReadUserById(int id);
    }
}