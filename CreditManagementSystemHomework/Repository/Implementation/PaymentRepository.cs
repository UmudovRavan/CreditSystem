using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly CreditManagementDB _context;
        public PaymentRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Payment>> GetAllWithLoansAsync()
        {
            return await _context.Payment.Include(p=>p.Loan)
                        .ThenInclude(l => l.Customer)
                        .Include(p => p.Loan.Employee)
                        .Where(p => !p.IsDeleted)
                        .ToListAsync();
        }

        public async Task<Payment?> GetByIdWithLoanAsync(int id)
        {
            return await _context.Payment
                .Include(p=>p.Loan)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByLoanIdAsync(int loanId)
        {
            return await _context.Payment
                .Include(p=> p.Loan)
                .Where(c => c.LoanId == loanId)
                .ToListAsync();
        }
    }
}
