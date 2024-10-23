using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class CartService
    {
        
        private readonly IMongoCollection<Cart> _cart;

        public CartService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _cart = database.GetCollection<Cart>("Cart");
        }

        public async Task<List<Cart>> GetAsync() =>
            await _cart.Find(new BsonDocument()).ToListAsync();

        public async Task<Cart> GetAsync(string id) =>
            await _cart.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task<Cart> GetAsyncByNameUser(string nameUser) =>
            await _cart.Find(x => x.nameUser == nameUser).FirstOrDefaultAsync();

        public async Task CreateAsync(Cart cart) =>
            await _cart.InsertOneAsync(cart);

        public async Task UpdateAsync(string id, Cart cart) =>
            await _cart.ReplaceOneAsync(x => x.Id == id, cart);
        
        

        public async Task RemoveAsync(string id) =>
            await _cart.DeleteOneAsync(x => x.Id == id);
    }
}
