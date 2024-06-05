using PeopleSystem.Database.Models;

namespace PeopleSystem.Database.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        User ReadUserById(int id);
        User ReadUserByUsername(string username);
        List<User> ReadAllUsers();
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}