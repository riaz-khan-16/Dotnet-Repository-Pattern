using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repository_Pattern.Entity;
using Repository_Pattern.Models;

namespace Repository_Pattern.Services
{
    public class DBService: IDBService                          /// every entity must have these fields
    {

       
            
        private readonly IMongoDatabase _database;

        public DBService(IOptions<MongoSetting> settings)
            {

                var client = new MongoClient(settings.Value.ConnectionString);
                _database = client.GetDatabase(settings.Value.DatabaseName);

        }

        public IMongoCollection<T> GetCollection<T>() where T:BaseEntity
        {

            var collectionName = typeof(T).Name + "s";
           return  _database.GetCollection<T>(collectionName);

        }
            



        public async Task<List<T>> GetAllItemAsync<T>() where T : BaseEntity
        {

            var collection = GetCollection<T>();

            return await collection.Find(_ => true).ToListAsync();
            }


            public async Task<T?> GetItemByIdAsync<T>(string id) where T : BaseEntity
            {
                var collection = GetCollection<T>();
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }


            public async Task SaveItemAsync<T>(T entity) where T : BaseEntity
            {
            var collection = GetCollection<T>();
            await collection.InsertOneAsync(entity);
            }

            public async Task UpdateItemByIdAsync<T>(string id, T entity) where T : BaseEntity
            {
            var collection = GetCollection<T>();
            await collection.ReplaceOneAsync(x => x.Id == id, entity);
            }

            public async Task DeleteItemByIdAsync<T>(string id) where T : BaseEntity
            { 
                
                var collection = GetCollection<T>();

            await collection.DeleteOneAsync(x => x.Id == id);

            }




    }



    
}
