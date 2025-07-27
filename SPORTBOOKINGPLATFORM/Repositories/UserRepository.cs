using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SportsBookingDbContext _context;
        UserDAO userDAO = new UserDAO();


        public UserRepository(SportsBookingDbContext context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
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

        public User? GetUserById(int id)
        {
            return userDAO.GetUserById(id);
        }

        public List<User> GetUsersByRoles(params int[] roleIds)
        {
            return userDAO.GetUsersByRoles(roleIds);
        }
    }
}
