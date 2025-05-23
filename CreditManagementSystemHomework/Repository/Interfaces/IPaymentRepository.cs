using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllWithLoansAsync();
        Task<Payment?> GetByIdWithLoanAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByLoanIdAsync(int loanId);
    }
}
