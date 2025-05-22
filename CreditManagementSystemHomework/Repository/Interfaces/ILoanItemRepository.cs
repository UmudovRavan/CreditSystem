using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface ILoanItemRepository : IGenericRepository<LoanItem>
    {
        Task<IEnumerable<LoanItem>> GetAllWithLoanAndProductAsync();
        Task<IEnumerable<LoanItem>> GetLoanItemsWithProductAsync(int loanId);
        Task<LoanItem?> GetLoanItemWithProductAsync(int id);
    }
}
