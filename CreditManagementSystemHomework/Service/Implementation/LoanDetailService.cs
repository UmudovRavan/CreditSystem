using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.LoanDetail;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class LoanDetailService : GenericService<LoanDetailVM, LoanDetail>, ILoanDetailService
    {
        private readonly ILoanDetailRepository _loanDetailRepository;
        private readonly IMapper _mapper;
        public LoanDetailService(ILoanDetailRepository loanDetailRepository, IMapper mapper) : base(loanDetailRepository, mapper)
        {
            _loanDetailRepository = loanDetailRepository;
            _mapper = mapper;
        }
        public async Task<LoanDetailCreateVM> CreateWithLoansAsync(LoanDetailCreateVM loanDetailCreateVM)
        {
            if (loanDetailCreateVM == null) return null;
            var loanDetailEntity = _mapper.Map<LoanDetail>(loanDetailCreateVM);
            var createdLoanDetail = await _loanDetailRepository.AddAsync(loanDetailEntity);
            await _loanDetailRepository.SaveChangesAsync();
            var result = _mapper.Map<LoanDetailCreateVM>(createdLoanDetail);
            return result;
        }

        public async Task<IEnumerable<LoanDetailVM>> GetAllWithLoansAsync()
        {
            var loanDetails = await _loanDetailRepository.GetAllWithLoansAsync();
            return _mapper.Map<IEnumerable<LoanDetailVM>>(loanDetails); 
        }

        public async Task<LoanDetailEditVM?> GetByIdVMWithLoansAndPaymentsAsync(int id)
        {
            var data = await _loanDetailRepository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<LoanDetailEditVM>(data);
        }

        public async Task<LoanDetailVM?> GetByIdWithLoansAsync(int id)
        {
            var data = await _loanDetailRepository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<LoanDetailVM>(data);
        }

        public async Task<LoanDetailVM?> GetByLoanIdAsync(int loanId)
        {
            if (loanId <= 0) return null;

            var loanDetail = await _loanDetailRepository.GetByLoanIdAsync(loanId);
            if(loanDetail != null)
            {
                var result = _mapper.Map<LoanDetailVM>(loanDetail);
                return result;
            }
            else { return null; }
        }

        public async Task<LoanDetailEditVM> UpdateWithLoansAsync(LoanDetailEditVM loanDetailEditVM)
        {
            if (loanDetailEditVM == null) return null;
            var loanDetailEntity = _mapper.Map<LoanDetail>(loanDetailEditVM);
            var updatedLoanDetail = await _loanDetailRepository.UpdateAsync(loanDetailEntity);
            await _loanDetailRepository.SaveChangesAsync();
            var result = _mapper.Map<LoanDetailEditVM>(updatedLoanDetail);
            return result;
        }
    }
}
