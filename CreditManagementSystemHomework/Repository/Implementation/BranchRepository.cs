using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        private readonly CreditManagementDB _context;
        public BranchRepository(CreditManagementDB context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetBranchesByMerchantIdAsync(int merchantId)
        {
            return await _context.Branches
                        .Where(b=>b.MerchantId == merchantId && !b.IsDeleted)
                        .ToListAsync();
        }
    }
}
