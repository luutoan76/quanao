using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class FavourtieService
    {
        
        private readonly IMongoCollection<Favourtie> _favourite;

        public FavourtieService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _favourite = database.GetCollection<Favourtie>("Favourite");
        }

        public async Task<List<Favourtie>> GetAsync() =>
            await _favourite.Find(new BsonDocument()).ToListAsync();

        public async Task<Favourtie> GetAsync(string id) =>
            await _favourite.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Favourtie>> GetAsyncByUsername(string username) =>
            await _favourite.Find(x => x.username == username).ToListAsync();

        public async Task CreateAsync(Favourtie favourtie) =>
            await _favourite.InsertOneAsync(favourtie);

        public async Task UpdateAsync(string id, Favourtie favourtie) =>
            await _favourite.ReplaceOneAsync(x => x.Id == id, favourtie);

        public async Task RemoveAsync(string idPro) =>
            await _favourite.DeleteOneAsync(x => x.idPro == idPro);
    }
}
