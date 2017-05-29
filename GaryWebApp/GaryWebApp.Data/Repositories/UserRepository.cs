using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GaryWebApp.Data.Contexts;
using GaryWebApp.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GaryWebApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(IOptions<Settings> settings)
        {
            _context = new UserContext(settings);
        }

        public async Task AddUserAsync(User user)
        {
            user.Id = ObjectId.GenerateNewId().ToString();
			await _context.Users.InsertOneAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
			return await _context.Users.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq(s => s.Id, id);
			return await _context.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> RemoveUserAsync(string id)
        {
			var filter = Builders<User>.Filter.Eq(s => s.Id, id);
			return await _context.Users.DeleteOneAsync(filter);
        }

        public async Task<UpdateResult> UpdateUserPasswordAsync(string id, string newPassword)
        {
			var filter = Builders<User>.Filter.Eq(s => s.Id, id);
            var update = Builders<User>.Update.Set(s => s.Password, newPassword);
            return await _context.Users.UpdateOneAsync(filter, update);
        }
    }
}
