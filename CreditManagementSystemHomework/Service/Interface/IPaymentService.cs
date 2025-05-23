using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Payment;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface IPaymentService : IGenericService<PaymentVM,Payment>
    {
        Task<IEnumerable<PaymentVM>> GetAllWithLoansAsync();
        Task<PaymentVM?> GetByIdWithLoanAsync(int id);
        Task<IEnumerable<PaymentVM>> GetPaymentsByLoanIdAsync(int loanId);

        Task<PaymentCreateVM> CreateWithLoanAsync(PaymentCreateVM paymentCreateVM);
        Task<PaymentUpdateVM> UpdateWithLoanAsync(PaymentUpdateVM paymentUpdateVM);
        Task<PaymentUpdateVM?> GetByIdVMUpdateVMWithLoanAsync(int id);
    }
}
