using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class UserService
    {
        
        private readonly IMongoCollection<User> _user;
        public UserService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _user = database.GetCollection<User>("User");
        }

        public async Task<List<User>> GetAsync() =>
            await _user.Find(new BsonDocument()).ToListAsync();

        public async Task<User> GetAsync(string id) =>
            await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _user.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User user) =>
            await _user.ReplaceOneAsync(x => x.Id == id, user);

        public async Task RemoveAsync(string id) =>
            await _user.DeleteOneAsync(x => x.Id == id);
        
        public async Task<User> GetByUsernameAsync(string username) =>
            await _user.Find(x => x.username == username).FirstOrDefaultAsync();

        public async Task CreateUserAsync(User user) =>
            await _user.InsertOneAsync(user);
    }
}
