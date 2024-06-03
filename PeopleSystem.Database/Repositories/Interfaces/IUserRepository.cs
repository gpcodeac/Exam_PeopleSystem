using PeopleSystem.Database.Models;

namespace PeopleSystem.Database.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        void CreateUser(User user);
        User ReadUserById(int id);
        User ReadUserByUsername(string username);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}