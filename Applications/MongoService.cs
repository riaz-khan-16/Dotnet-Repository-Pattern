using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repository_Pattern.Models;




namespace Repository_Pattern.Services
{
    public class MongoService
    {

        private readonly IMongoDatabase _database;

        public MongoService(IOptions<MongoSetting> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
            => _database.GetCollection<T>(name);
    }
}
