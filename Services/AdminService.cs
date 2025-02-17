using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class AdminService
    {
        
        private readonly IMongoCollection<AdminAccount> _user;
        public AdminService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _user = database.GetCollection<AdminAccount>("AdminAccount");
        }

        public async Task<List<AdminAccount>> GetAsync() =>
            await _user.Find(new BsonDocument()).ToListAsync();

        public async Task<AdminAccount> GetAsync(string id) =>
            await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AdminAccount user) =>
            await _user.InsertOneAsync(user);

        public async Task UpdateAsync(string id, AdminAccount user) =>
            await _user.ReplaceOneAsync(x => x.Id == id, user);

        public async Task RemoveAsync(string id) =>
            await _user.DeleteOneAsync(x => x.Id == id);
        
        public async Task<AdminAccount> GetByUsernameAsync(string username) =>
            await _user.Find(x => x.username == username).FirstOrDefaultAsync();

        public async Task CreateUserAsync(AdminAccount user) =>
            await _user.InsertOneAsync(user);
    }
}
