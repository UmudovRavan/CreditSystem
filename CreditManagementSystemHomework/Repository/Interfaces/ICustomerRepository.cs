using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithLoanAsync();
        Task<Customer?> GetByIdWithLoanAsync(int id);
    }
}
