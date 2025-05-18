using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Customer;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class CustomerService : GenericService<CustomerVM, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<CustomerCreateVM> CreateWithLoansAsync(CustomerCreateVM customerCreateVM)
        {
            if(customerCreateVM == null) return null;
            var customerEntity = _mapper.Map<Customer>(customerCreateVM);
            var createdCustomer = await _customerRepository.AddAsync(customerEntity);
            await _customerRepository.SaveChangesAsync();
            return _mapper.Map<CustomerCreateVM>(createdCustomer);
        }

        public async Task<IEnumerable<CustomerVM>> GetAllWithLoansAsync()
        {
            var customers = await _customerRepository.GetAllWithLoanAsync();
            return _mapper.Map<IEnumerable<CustomerVM>>(customers);

        }

        public async Task<CustomerEditVM?> GetByIdVMUpdateVMWithLoansAsync(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<CustomerEditVM>(data);
        }

        public async Task<CustomerVM?> GetByIdWithLoansAsync(int id)
        {
            if (id <= 0) return null;
            var customer = await _customerRepository.GetByIdWithLoanAsync(id);
            return customer != null ? _mapper.Map<CustomerVM>(customer) : null;
        }

        public async Task<CustomerEditVM> UpdateWithLoansAsync(CustomerEditVM customerUpdateVM)
        {
            if (customerUpdateVM == null) return null;
            var customerEntity = _mapper.Map<Customer>(customerUpdateVM);
            var updatedCustomer = await _customerRepository.UpdateAsync(customerEntity);
            await _customerRepository.SaveChangesAsync();
            return _mapper.Map<CustomerEditVM>(updatedCustomer);
        }
    }
}
