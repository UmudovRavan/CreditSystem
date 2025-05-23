using CreditManagementSystemHomework.Service.Implementation;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Extentions
{
    public static class CustomServiceRegistration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IMerchantService,MerchantService>();
            services.AddScoped<IBranchService,BranchService>();
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanDetailService, LoanDetailService>();
            services.AddScoped<ILoanItemService, LoanItemService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}
