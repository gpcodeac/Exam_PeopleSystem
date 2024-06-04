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

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
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

        public void CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<UserDto, User>(userDto);
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = Database.Enums.Role.User;
            _userRepository.CreateUser(user);
        }


        public void Login(UserDto userDto)
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
            //create token and login
        }

        public User ReadUserById(int id)
        {
            return _userRepository.ReadUserById(id);
        }
    }
}
