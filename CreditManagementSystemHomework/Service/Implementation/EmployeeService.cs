using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class EmployeeService : GenericService<EmployeeVM, Employee>, IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
