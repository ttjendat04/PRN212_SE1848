﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmailAndPassword(email, password);
            return user;
        }

        public bool Register(User user)
        {
            var existed = _userRepository.GetUserByEmail(user.Email);
            if (existed != null) return false;

            _userRepository.AddUser(user);
            return true;
        }

       
    }
}
