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

            public async Task<List<T>> GetAllAsync()
            {
                return await _dbContext.Find(_ => true).ToListAsync();
            }


            public async Task<T?> GetByIdAsync(string id)
            {
                return await _dbContext.Find(x => x.Id == id).FirstOrDefaultAsync();
            }


            public async Task CreateAsync(T entity)
            { await _dbContext.InsertOneAsync(entity); }

            public async Task UpdateAsync(string id, T entity)
            { await _dbContext.ReplaceOneAsync(x => x.Id == id, entity); }

            public async Task DeleteAsync(string id)
            { await _dbContext.DeleteOneAsync(x => x.Id == id); }
        
    
    
    }



    
}
