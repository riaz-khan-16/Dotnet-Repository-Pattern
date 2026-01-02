using MongoDB.Driver;
using Repository_Pattern.Entity;

namespace Repository_Pattern.Services
{
    public class DBService<T>: IDBService<T>
        where T : BaseEntity
    {

       
            private readonly IMongoCollection<T> _dbContext;

            public DBService(MongoService mongoService)
            {
            var collectionName = typeof(T).Name + "s";
            _dbContext = mongoService.GetCollection<T>(collectionName);
            }

            public async Task<List<T>> GetAllItemAsync()
            {
                return await _dbContext.Find(_ => true).ToListAsync();
            }


            public async Task<T?> GetItemByIdAsync(string id)
            {
                return await _dbContext.Find(x => x.Id == id).FirstOrDefaultAsync();
            }


            public async Task SaveItemAsync(T entity)
            { await _dbContext.InsertOneAsync(entity); }

            public async Task UpdateItemByIdAsync(string id, T entity)
            { await _dbContext.ReplaceOneAsync(x => x.Id == id, entity); }

            public async Task DeleteItemByIdAsync(string id)
            { await _dbContext.DeleteOneAsync(x => x.Id == id); }
        
    
    
    }



    
}
