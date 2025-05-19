using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Loan;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface ILoanService : IGenericService<LoanVM, Loan>
    {
        Task<IEnumerable<LoanVM>> GetLoansWithCustomerAndEmployeeAsync();
        Task<IEnumerable<LoanVM>> GetLoansByCustomerIdAsync(int customerId);
        Task<IEnumerable<LoanVM>> GetLoansByEmployeeIdAsync(int employeeId);
        Task<LoanCreateVM> CreateVMAsync(LoanCreateVM loanCreateVM);
        Task<LoanEditVM> UpdateVMAsync(LoanEditVM loanUpdateVM);
        Task<LoanEditVM> GetLoanUpdateVMByCustomerIdAsync(int id);
    }
}
