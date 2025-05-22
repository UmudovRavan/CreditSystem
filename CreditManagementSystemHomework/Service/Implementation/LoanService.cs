using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Loan;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class LoanService : GenericService<LoanVM, Loan>, ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;
        public LoanService(ILoanRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public override async Task<IEnumerable<LoanVM>> GetAllAsync()
        {
            var loans = await _repository.GetLoansWithCustomerAndEmployeeAsync(); 
            return _mapper.Map<IEnumerable<LoanVM>>(loans);
        }

        public async Task<IEnumerable<LoanVM>> GetLoansWithCustomerAndEmployeeAsync()
        {
            var loans = await _repository.GetLoansWithCustomerAndEmployeeAsync();
            return _mapper.Map<IEnumerable<LoanVM>>(loans);
        }
        public async Task<IEnumerable<LoanVM>> GetLoansByCustomerIdAsync(int customerId)
        {
            if (customerId <= 0)
                return Enumerable.Empty<LoanVM>();
            var loans = await _repository.GetLoansByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<LoanVM>>(loans);
        }
        public async Task<IEnumerable<LoanVM>> GetLoansByEmployeeIdAsync(int employeeId)
        {
            if (employeeId <= 0)
                return Enumerable.Empty<LoanVM>();
            var loans = await _repository.GetLoansByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<LoanVM>>(loans);
        }
        public async Task<LoanCreateVM> CreateVMAsync(LoanCreateVM loanCreateVM)
        {
            if (loanCreateVM == null) return null;
            var loanEntity = _mapper.Map<Loan>(loanCreateVM);
            var createdLoan = await _repository.AddAsync(loanEntity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<LoanCreateVM>(createdLoan);
        }
        public async Task<LoanEditVM> UpdateVMAsync(LoanEditVM loanUpdateVM)
        {
            if (loanUpdateVM == null) return null;
            var loanEntity = _mapper.Map<Loan>(loanUpdateVM);
            var updatedLoan =await  _repository.UpdateAsync(loanEntity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<LoanEditVM>(updatedLoan);
        }

        public async Task<LoanEditVM> GetLoanUpdateVMByCustomerIdAsync(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<LoanEditVM>(data);
        }
    }
}
