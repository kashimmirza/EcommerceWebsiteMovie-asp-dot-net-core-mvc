using EcommerceWebsiteMovie.Models;

namespace EcommerceWebsiteMovie.Data.Base
{
    public interface IEntityBaseRepository< T> where T : class,IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
