using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Models.Customer;
using CreditManagementSystemHomework.Models.Product;

namespace CreditManagementSystemHomework.Profiles
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<MerchantVM,Merchant>().ReverseMap();  
            CreateMap<BranchVM,Branch>().ReverseMap();  
            CreateMap<EmployeeVM,Employee>().ReverseMap();
            CreateMap<CategoryVM, Category>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductCreateVM, Product>().ReverseMap();
            CreateMap<ProductEditVM, Product>().ReverseMap();

            CreateMap<CustomerVM, Customer>().ReverseMap();
            CreateMap<CustomerCreateVM, Customer>().ReverseMap();
            CreateMap<CustomerEditVM, Customer>().ReverseMap();

        }
    }
}
