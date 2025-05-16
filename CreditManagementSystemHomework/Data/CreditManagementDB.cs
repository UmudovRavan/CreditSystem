using CreditManagementSystemHomework.Entities;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Data
{
    public class CreditManagementDB :DbContext
    {
        public CreditManagementDB(DbContextOptions<CreditManagementDB> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> LoansItem { get; set; }
        public DbSet<LoanDetail> LoansDetail { get; set; }
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
