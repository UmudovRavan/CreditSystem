using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.LoanItem;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface ILoanItemService : IGenericService<LoanItemVM,LoanItem>
    {
        Task<IEnumerable<LoanItemVM>> GetAllWithLoanAndProductAsync();
        Task<IEnumerable<LoanItemVM>> GetLoanItemsWithProductAsync(int loanId);
        Task<LoanItemVM?> GetLoanItemWithProductAsync(int id);

        Task<LoanItemCreateVM> CreateWithLoanAndProductAsync(LoanItemCreateVM loanItemCreateVM);
        Task<LoanItemEditVM> UpdateWithLoanAndProductAsync(LoanItemEditVM loanItemUpdateVM);
        Task<LoanItemEditVM?> GetByIdVMWithLoanAndProductAsync(int id);
    }
}
