using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GaryWebApp.Data.Models;

namespace GaryWebApp.Business.Services
{
    public interface IUserService
    {
        Task CreateAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task UpdateUserPasswordAsync(string userId, string newPassword);
    }
}
