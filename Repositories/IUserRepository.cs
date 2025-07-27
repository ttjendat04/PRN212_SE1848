using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories
{
    public interface IUserRepository
    {
        User? GetUserByEmailAndPassword(string email, string password);
        void AddUser(User user);
        User GetUserByEmail(string email);
        public List<User> GetAllUsers();
        public User? GetUserById(int id);
        public List<User> GetUsersByRoles(params int[] roleIds);
    }
}
