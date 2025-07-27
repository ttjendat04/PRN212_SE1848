using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAO
    {
        SportsBookingDbContext context = new SportsBookingDbContext();
        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public  List<User> GetUsersByRoles(params int[] roleIds)
        {
            return context.Users
                          .Where(u => roleIds.Contains(u.RoleId))
                          .ToList();
        }
    }
}
