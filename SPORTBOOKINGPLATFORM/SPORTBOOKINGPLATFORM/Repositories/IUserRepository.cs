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
        User? GetUserByEmail(string email);
        List<User> GetUsers();
    }
}
