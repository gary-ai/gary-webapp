using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GaryWebApp.Data.Models;
using GaryWebApp.Data.Repositories;

namespace GaryWebApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateAsync(string username, string password)
        {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = new User
                {
                    Username = username,
                    Password = password
                };

                await _userRepository.AddUserAsync(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return await _userRepository.GetUserByIdAsync(id);
            }
            return null;
        }

        public async Task UpdateUserPasswordAsync(string userId, string newPassword)
        {
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(newPassword))
            {
                await _userRepository.UpdateUserPasswordAsync(userId, newPassword);
               
            }
        }
    }
}
