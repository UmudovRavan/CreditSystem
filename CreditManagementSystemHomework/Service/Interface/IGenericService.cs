using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface IGenericService<TModel, TEntity> where TEntity : BaseEntity where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int id);
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> Update(TModel model);
        Task<bool> DeleteAsync(int id);
    }
}
