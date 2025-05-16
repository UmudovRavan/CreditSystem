using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    { 
        private readonly CreditManagementDB _context;
        public EmployeeRepository(CreditManagementDB context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByBranchIdAsync(int branchId)
        {
            return await _context.Employees
                        .Where(e=> e.BranchId == branchId && !e.IsDeleted)
                        .ToListAsync();
        }
    }
}
