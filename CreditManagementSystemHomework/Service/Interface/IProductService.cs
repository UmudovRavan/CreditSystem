using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Models.Product;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface IProductService : IGenericService<ProductVM, Product>
    {
        Task<IEnumerable<ProductVM>> GetAllWithCategoryAsync();
        Task<ProductVM?> GetByIdWithCategoryAsync(int id);
        Task<IEnumerable<ProductVM>> GetProductsByCategoryIdAsync(int categoryId);

        Task<ProductCreateVM> CreateWithCategoryAsync(ProductCreateVM productCreateVM);
        Task<ProductEditVM> UpdateWithCategoryAsync(ProductEditVM productUpdateVM);

        Task<ProductEditVM?> GetUpdateVMByIdAsync(int id);

        Task<ProductCreateVM> CreateWithImageAsync(ProductCreateVM vm);
        Task<ProductEditVM> UpdateWithImageAsync(ProductEditVM updateVM);

        Task<bool> DeleteWithImageAsync(int id);
    }
}
