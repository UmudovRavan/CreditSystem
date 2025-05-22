using CreditManagementSystemHomework.Repository.Implementation;
using CreditManagementSystemHomework.Repository.Interfaces;

namespace CreditManagementSystemHomework.Extentions
{
    public static class CustomRepositoryRegistration
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMercahntRepository,MerchantRepository>();
            services.AddScoped<IBranchRepository,BranchRepository>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoanDetailRepository, LoanDetailRepository>();
            services.AddScoped<ILoanItemRepository, LoanItemRepository>();
        }
    }
}
