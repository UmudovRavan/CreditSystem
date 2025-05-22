using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface ILoanDetailRepository : IGenericRepository<LoanDetail>
    {
        Task<IEnumerable<LoanDetail>> GetAllWithLoansAsync();
        Task<LoanDetail?> GetByLoanIdAsync(int loanId);
    }
}
