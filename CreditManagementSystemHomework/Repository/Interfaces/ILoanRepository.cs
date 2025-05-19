using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Implementation;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoansWithCustomerAndEmployeeAsync();
        Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId);
        Task<IEnumerable<Loan>> GetLoansByEmployeeIdAsync(int employeeId);
    }
}
