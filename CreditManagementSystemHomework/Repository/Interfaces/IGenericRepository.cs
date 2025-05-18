using CreditManagementSystemHomework.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);

        Task<int> SaveChangesAsync(); // SaveChanges buraya əlavə olunur
    }
}
