using PeopleSystem.Database.Repositories.Interfaces;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Services.Interfaces;

namespace PeopleSystem.BusinessLogic.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }

        public User ReadUserById(int id)
        {
            return _userRepository.ReadUserById(id);
        }
    }
}
