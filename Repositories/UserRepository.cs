using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using User = BusinessObjects.User;
using System.Collections.ObjectModel;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SportsBookingDbContext _context;

        public UserRepository(SportsBookingDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
           return  _context.Users.
                FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == email 
                && u.PasswordHash == password);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            var existing = _context.Users.Find(user.UserId);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
