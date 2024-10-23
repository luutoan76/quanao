using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class ReviewService
    {
        
        private readonly IMongoCollection<Review> _review;

        public ReviewService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _review = database.GetCollection<Review>("Review");
        }

        public async Task<List<Review>> GetAsync() =>
            await _review.Find(new BsonDocument()).ToListAsync();

        public async Task<List<Review>> GetAsync(string idPro) =>
            await _review.Find(x => x.idPro == idPro).ToListAsync();

        public async Task CreateAsync(Review review) =>
            await _review.InsertOneAsync(review);

        public async Task UpdateAsync(string id, Review review) =>
            await _review.ReplaceOneAsync(x => x.Id == id, review);

        public async Task RemoveAsync(string id) =>
            await _review.DeleteOneAsync(x => x.Id == id);
    }
}
