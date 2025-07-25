using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

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

        public User? GetUserByEmail(string email)
        {
           return  _context.Users.
                FirstOrDefault(u => u.Email == email);
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email 
                && u.PasswordHash == password);
        }

        public List<User> GetUsers()
        {
            return _context.Users
                .Include(u => u.Role)
                .ToList();
        }
    }
}
