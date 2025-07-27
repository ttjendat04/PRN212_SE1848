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
        // CRUD bổ sung
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User? GetUserById(int userId);
    }
}
