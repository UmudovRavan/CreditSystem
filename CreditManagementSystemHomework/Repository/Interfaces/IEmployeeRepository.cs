using CreditManagementSystemHomework.Entities;

namespace CreditManagementSystemHomework.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByBranchIdAsync(int branchId);
    }
}
