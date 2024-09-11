using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class OrderService
    {
        
        private readonly IMongoCollection<Order> _order;

        public OrderService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _order = database.GetCollection<Order>("Order");
        }

        public async Task<List<Order>> GetAsync() =>
            await _order.Find(new BsonDocument()).ToListAsync();

        public async Task<Order> GetAsync(string id) =>
            await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Order>> GetAsyncByName(string username) =>
            await _order.Find(x => x.username == username).ToListAsync();

        public async Task CreateAsync(Order order) =>
            await _order.InsertOneAsync(order);

        public async Task UpdateAsync(string id, Order order) =>
            await _order.ReplaceOneAsync(x => x.Id == id, order);

        public async Task RemoveAsync(string id) =>
            await _order.DeleteOneAsync(x => x.Id == id);
    }
}
