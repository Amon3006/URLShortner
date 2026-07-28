using MongoDB.Driver;
using UrlShortener.Api.Data;
using UrlShortener.Api.Models;

namespace UrlShortener.Api.Repository
{
    public class UrlRepository : IUrlRepository
    {

        private readonly IMongoCollection<Url> _collection;

        public UrlRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<Url>("Urls");
        }
        public async Task CreateAsync(Url url)
        {
            await _collection.InsertOneAsync(url);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Url>> GetAllAsync()
        {
            return await _collection
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Url?> GetByIdAsync(string id)
        {
            return await _collection
                .Find(u => u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Url?> GetByShortCodeAsync(string shortCode)
        {
            return await _collection
                .Find(u => u.ShortCode == shortCode)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ShortCodeExistsAsync(string shortCode)
        {
            var url = await _collection
                .Find(u => u.ShortCode == shortCode)
                .FirstOrDefaultAsync();
            return url != null;
           
        }

        public async Task UpdateAsync(Url url)
        {
            await _collection.ReplaceOneAsync(
         x => x.Id == url.Id,
         url);
        }
    }
}
