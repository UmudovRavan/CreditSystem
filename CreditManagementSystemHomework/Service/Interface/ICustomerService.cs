using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Customer;

namespace CreditManagementSystemHomework.Service.Interface
{
    public interface ICustomerService :IGenericService<CustomerVM,Customer>
    {
        Task<IEnumerable<CustomerVM>> GetAllWithLoansAsync();
        Task<CustomerVM?> GetByIdWithLoansAsync(int id);

        Task<CustomerCreateVM> CreateWithLoansAsync(CustomerCreateVM customerCreateVM);
        Task<CustomerEditVM> UpdateWithLoansAsync(CustomerEditVM customerUpdateVM);
        Task<CustomerEditVM?> GetByIdVMUpdateVMWithLoansAsync(int id);
    }
}
