using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CreditManagementDB _context;
        public CustomerRepository(CreditManagementDB context) :base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllWithLoanAsync(int loanId)
        {
            return await _context.Customers
                .Include(c => c.Loan)
                .Where(c=>!c.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllWithLoanAsync()
        {
            return await _context.Customers
       .Include(c => c.Loan)  
       .ToListAsync();
        }

        public async Task<Customer?> GetByIdWithLoanAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Loan)
                .FirstOrDefaultAsync(c=>c.Id == id);
        }
    }
}
