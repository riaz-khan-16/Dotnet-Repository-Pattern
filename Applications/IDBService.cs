using Repository_Pattern.Entity;
using System.Threading.Tasks;

namespace Repository_Pattern.Services
{
    public interface IDBService
    {

        Task<List<T>> GetAllItemAsync<T>() where T: BaseEntity;
        Task<T?> GetItemByIdAsync<T>(string id) where T : BaseEntity;
        Task    SaveItemAsync<T>(T Entity) where T : BaseEntity;
        Task UpdateItemByIdAsync<T>(string id, T entity) where T : BaseEntity;
        Task DeleteItemByIdAsync<T>(string id) where T : BaseEntity;
    }
}
