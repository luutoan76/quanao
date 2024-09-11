using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class ProductService
    {
        
        private readonly IMongoCollection<Product> _products;

        public ProductService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _products = database.GetCollection<Product>("Product");
        }

        public async Task<List<Product>> GetAsync() =>
            await _products.Find(new BsonDocument()).ToListAsync();

        public async Task<Product> GetAsync(string id) =>
            await _products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Product>> SearchByNameAsync(string name)
        {
            var filter = Builders<Product>.Filter.Regex("name", new BsonRegularExpression(name, "i"));
            return await _products.Find(filter).ToListAsync();
        }
        public async Task CreateAsync(Product product) =>
            await _products.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Product product) =>
            await _products.ReplaceOneAsync(x => x.Id == id, product);

        public async Task RemoveAsync(string id) =>
            await _products.DeleteOneAsync(x => x.Id == id);
    }
}
