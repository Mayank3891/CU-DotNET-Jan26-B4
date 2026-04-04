using MongoDB.Driver;
using VoltGear.Models;
using VoltGear.Settings;
using Microsoft.Extensions.Options;

namespace VoltGear.Services
{
    public class LaptopService
    {
        private readonly IMongoCollection<Laptop> _collection;

        public LaptopService(IOptions<DatabaseSettings> options)
        {
            var settings = options.Value;

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Laptop>(settings.CollectionName);
        }

        public async Task<List<Laptop>> GetAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Laptop laptop)
        {
            await _collection.InsertOneAsync(laptop);
        }
    }
}