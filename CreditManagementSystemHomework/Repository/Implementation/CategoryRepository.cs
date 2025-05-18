using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CreditManagementDB creditManagement) : base(creditManagement)
        {
            
        }
    }
}
