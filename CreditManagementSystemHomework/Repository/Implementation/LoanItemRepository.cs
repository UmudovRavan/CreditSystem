using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class LoanItemRepository : GenericRepository<LoanItem>, ILoanItemRepository
    {
        private readonly CreditManagementDB _context;
        public LoanItemRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoanItem>> GetAllWithLoanAndProductAsync()
        {
            return await _context.LoansItem
                .Include(li => li.Loan)
                .Include(li => li.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanItem>> GetLoanItemsWithProductAsync(int loanId)
        {
            return await _context.LoansItem
                .Include(li => li.Product)
                .Where(li => li.LoanId == loanId)
                .ToListAsync();
        }

        public async Task<LoanItem?> GetLoanItemWithProductAsync(int id)
        {
            return await _context.LoansItem
                .Include(li => li.Product)
                .FirstOrDefaultAsync(li => li.Id == id);
        }
    }
}
