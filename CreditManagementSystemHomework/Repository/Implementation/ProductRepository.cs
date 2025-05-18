using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CreditManagementDB _context;
        public ProductRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products
                    .Include(p => p.Category)
                    .Where(p => !p.IsDeleted)
                    .ToListAsync();
        }

        public async Task<Product?> GetByIdWithCategoryAsync(int id)
        {
            return await _context.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                    .Where(p => p.CategoryId == categoryId)
                    .ToListAsync();
        }
    }
    
}
