using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;

namespace CreditManagementSystemHomework.Profiles
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<MerchantVM,Merchant>().ReverseMap();  
            CreateMap<BranchVM,Branch>().ReverseMap();  
            CreateMap<EmployeeVM,Employee>().ReverseMap();
        }
    }
}
