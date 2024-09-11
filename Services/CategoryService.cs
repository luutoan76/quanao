using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class CategoryService
    {
        
        private readonly IMongoCollection<Category> _category;

        public CategoryService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _category = database.GetCollection<Category>("Category");
        }

        public async Task<List<Category>> GetAsync() =>
            await _category.Find(new BsonDocument()).ToListAsync();

        public async Task<Category> GetAsync(string id) =>
            await _category.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category category) =>
            await _category.InsertOneAsync(category);

        public async Task UpdateAsync(string id, Category category) =>
            await _category.ReplaceOneAsync(x => x.Id == id, category);

        public async Task RemoveAsync(string id) =>
            await _category.DeleteOneAsync(x => x.Id == id);
    }
}
