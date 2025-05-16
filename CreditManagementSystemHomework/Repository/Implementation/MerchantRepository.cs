using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Repository.Interfaces;

namespace CreditManagementSystemHomework.Repository.Implementation
{
    public class MerchantRepository : GenericRepository<Merchant>, IMercahntRepository
    {
        public MerchantRepository(CreditManagementDB context) : base(context)
        {
        }
    }
}
