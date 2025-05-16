using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class MerchantService : GenericService<MerchantVM,Merchant>,IMerchantService
    {
        private readonly IGenericRepository<Merchant> _repository;
        private readonly IMapper _mapper;

        public MerchantService(IGenericRepository<Merchant> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
