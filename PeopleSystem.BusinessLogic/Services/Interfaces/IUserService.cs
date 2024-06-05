using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserRequestDto user);
        string Login(UserRequestDto user);
        List<User> GetAllUsers();
        UserResponseDto ReadUserById(int id);
    }
}