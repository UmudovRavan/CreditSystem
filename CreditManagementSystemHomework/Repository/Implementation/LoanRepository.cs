using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        private readonly CreditManagementDB _context;
        public LoanRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId)
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Where(l => l.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansByEmployeeIdAsync(int employeeId)
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansWithCustomerAndEmployeeAsync()
        {
            return await _context.Loans
                .Include(l => l.Customer)
                .Include(l => l.Employee)
                .ToListAsync();
        }
    }
}
