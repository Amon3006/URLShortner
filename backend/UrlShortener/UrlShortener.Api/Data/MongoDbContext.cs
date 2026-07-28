using MongoDB.Driver;
using Microsoft.Extensions.Options;
using UrlShortener.Api.Configurations;
namespace UrlShortener.Api.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var Client = new MongoClient(options.Value.ConnectionString);
            _database = Client.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
