using Microsoft.EntityFrameworkCore;
using PeopleSystem.Database.Models;
using PeopleSystem.Database.Repositories.Interfaces;

namespace PeopleSystem.Database.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;

        public UserRepository(AppDBContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User ReadUserById(int id)
        {
            return _context.Users.Include(u => u.PersonalInformation).FirstOrDefault(u => u.Id == id);
        }

        public User ReadUserByUsername(string username)
        {
            return _context.Users.Include(u => u.PersonalInformation).FirstOrDefault(u => u.Username == username);
        }

        public List<User> ReadAllUsers()
        {
            return [.. _context.Users.Include(u => u.PersonalInformation)]; //new syntax
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


    }
}
