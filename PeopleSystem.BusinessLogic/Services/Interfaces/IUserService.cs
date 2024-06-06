using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;

namespace PeopleSystem.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserSignupRequestDto user);
        string Login(UserLoginRequestDto user);
        List<UserDataForAdminResponseDto> GetAllUsers();
        UserDataForAdminResponseDto GetUser(int id);
        void DeleteUser(int id);
        void UpdateUserPassword(int id, string password);
    }
}