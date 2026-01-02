using Repository_Pattern.Entity;
using System.Threading.Tasks;

namespace Repository_Pattern.Services
{
    public interface IDBService<T>
    {

        Task<List<T>> GetAllItemAsync();
        Task<T?> GetItemByIdAsync(string id);
        Task    SaveItemAsync(T Entity);
        Task UpdateItemByIdAsync(string id, T entity);
        Task DeleteItemByIdAsync(string id);
    }
}
