﻿using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Models.Customer;
using CreditManagementSystemHomework.Models.Loan;
using CreditManagementSystemHomework.Models.LoanDetail;
using CreditManagementSystemHomework.Models.LoanItem;
using CreditManagementSystemHomework.Models.Payment;
using CreditManagementSystemHomework.Models.Product;

namespace CreditManagementSystemHomework.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<MerchantVM, Merchant>().ReverseMap();
            CreateMap<BranchVM, Branch>().ReverseMap();
            CreateMap<EmployeeVM, Employee>().ReverseMap();
            CreateMap<CategoryVM, Category>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductCreateVM, Product>().ReverseMap();
            CreateMap<ProductEditVM, Product>().ReverseMap();

            CreateMap<CustomerVM, Customer>().ReverseMap();
            CreateMap<CustomerCreateVM, Customer>().ReverseMap();
            CreateMap<CustomerEditVM, Customer>().ReverseMap();

            CreateMap<LoanCreateVM, Loan>().ReverseMap();
            CreateMap<LoanEditVM, Loan>().ReverseMap();


            CreateMap<Loan, LoanVM>()
                .ForMember(dest => dest.CustomerName,
                           opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.EmployeeName,
                           opt => opt.MapFrom(src => src.Employee.FullName));

            CreateMap<LoanDetailVM, LoanDetail>().ReverseMap();
            CreateMap<LoanDetailCreateVM, LoanDetail>().ReverseMap();
            CreateMap<LoanDetailEditVM, LoanDetail>().ReverseMap();

            CreateMap<LoanItemVM,LoanItem>().ReverseMap();
            CreateMap<LoanItemCreateVM, LoanItem>().ReverseMap();
            CreateMap<LoanItemEditVM, LoanItem>().ReverseMap();

            CreateMap<PaymentVM, Payment>().ReverseMap();
            CreateMap<PaymentCreateVM, Payment>().ReverseMap();
            CreateMap<PaymentUpdateVM, Payment>().ReverseMap();

        }
    }
}
