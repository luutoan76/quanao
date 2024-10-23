using MongoDB.Bson;
using MongoDB.Driver;
using quanao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace quanao.Services
{
    public class VoucherService
    {
        
        private readonly IMongoCollection<Voucher> _voucher;

        public VoucherService(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("Test");
            _voucher = database.GetCollection<Voucher>("Voucher");
        }

        public async Task<List<Voucher>> GetAsync() =>
            await _voucher.Find(new BsonDocument()).ToListAsync();

        public async Task<Voucher> GetAsync(string id) =>
            await _voucher.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Voucher voucher) =>
            await _voucher.InsertOneAsync(voucher);

        public async Task UpdateAsync(string id, Voucher voucher) =>
            await _voucher.ReplaceOneAsync(x => x.Id == id, voucher);

        public async Task RemoveAsync(string id) =>
            await _voucher.DeleteOneAsync(x => x.Id == id);
    }
}
