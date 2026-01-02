using Repository_Pattern.Entity;
using System.Threading.Tasks;

namespace Repository_Pattern.Services
{
    public interface IDBService<T>
    {

        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task CreateAsync(T Entity);
        Task UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
    }
}
