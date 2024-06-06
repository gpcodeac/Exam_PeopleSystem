using PeopleSystem.Database.Repositories.Interfaces;
using PeopleSystem.Database.Models;
using PeopleSystem.BusinessLogic.Dtos;
using PeopleSystem.BusinessLogic.Services.Interfaces;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace PeopleSystem.BusinessLogic.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public void CreateUser(UserSignupRequestDto userDto)
        {
            if (_userRepository.ReadUserByUsername(userDto.Username) is not null)
            {
                throw new Exception("User already exists");
            }
            var user = _mapper.Map<UserSignupRequestDto, User>(userDto);
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = Database.Enums.Role.User;
            _userRepository.CreateUser(user);
        }

        public string Login(UserLoginRequestDto userDto)
        {
            var user = _userRepository.ReadUserByUsername(userDto.Username);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            if (!VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Invalid password");
            }
            string token = _jwtService.GenerateSecurityToken(user);
            return token;
        }

        public List<UserDataForAdminResponseDto> GetAllUsers()
        {
            List<User> users = _userRepository.ReadAllUsers();
            return _mapper.Map<List<User>, List<UserDataForAdminResponseDto>>(users);
        }

        public UserDataForAdminResponseDto GetUser(int id)
        {
            var user = _userRepository.ReadUserById(id);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<User, UserDataForAdminResponseDto>(user);
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.ReadUserById(id);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            _userRepository.DeleteUser(user);
        }

        public void UpdateUserPassword(int id, string password)
        {
            var user = _userRepository.ReadUserById(id);
            if (user is null)
            {
                throw new Exception("User not found");
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userRepository.UpdateUser(user);
        }
    }
}
