using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public interface IUserService
    {
         User? Login(string email, string password);
        bool Register(User user);
        public List<User> GetAllUsers();
        public User? GetUserById(int id);
        public List<User> GetUsersByRoles(params int[] roleIds);

    }
}
