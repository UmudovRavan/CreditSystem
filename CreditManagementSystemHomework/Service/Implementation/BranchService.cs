using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class BranchService : GenericService<BranchVM,Branch> ,IBranchService
    {
        private readonly IGenericRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public BranchService(IGenericRepository<Branch> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
