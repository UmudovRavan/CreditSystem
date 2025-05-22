using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class LoanDetailRepository : GenericRepository<LoanDetail>, ILoanDetailRepository
    {
        private readonly CreditManagementDB _context;
        public LoanDetailRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoanDetail>> GetAllWithLoansAsync()
        {
            return await _context.LoansDetail
                .Include(ld => ld.Loan)
                .ToListAsync();
        }

        public Task<LoanDetail?> GetByLoanIdAsync(int loanId)
        {
            return _context.LoansDetail
                .Include(ld => ld.Loan)
                .FirstOrDefaultAsync(ld => ld.LoanId == loanId);
        }
    }
}
