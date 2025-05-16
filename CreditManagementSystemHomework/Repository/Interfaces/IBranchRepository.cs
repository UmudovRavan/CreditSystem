using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<IEnumerable<Branch>> GetBranchesByMerchantIdAsync(int merchantId); 
    }
}
