using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GaryWebApp.Data.Models;
using MongoDB.Driver;

namespace GaryWebApp.Data.Repositories
{
    public interface IUserRepository
    {
		Task<IEnumerable<User>> GetAllUsersAsync();
		Task<User> GetUserByIdAsync(string id);
		Task AddUserAsync(User user);
		Task<DeleteResult> RemoveUserAsync(string id);
        Task<UpdateResult> UpdateUserPasswordAsync(string id, string newPassword);
    }
}
