using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.LoanDetail;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface ILoanDetailService :IGenericService<LoanDetailVM,LoanDetail>
    {
        Task<IEnumerable<LoanDetailVM>> GetAllWithLoansAsync();
        Task<LoanDetailVM?> GetByLoanIdAsync(int loanId);
        Task<LoanDetailVM?> GetByIdWithLoansAsync(int id);
        Task<LoanDetailCreateVM> CreateWithLoansAsync(LoanDetailCreateVM loanDetailCreateVM);
        Task<LoanDetailEditVM> UpdateWithLoansAsync(LoanDetailEditVM loanDetailEditVM);
        Task<LoanDetailEditVM?> GetByIdVMWithLoansAndPaymentsAsync(int id);
    }
}
