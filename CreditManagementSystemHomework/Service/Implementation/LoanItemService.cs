using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Loan;
using CreditManagementSystemHomework.Models.LoanItem;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class LoanItemService : GenericService<LoanItemVM, LoanItem>, ILoanItemService
    {
        private readonly ILoanItemRepository _loanItemRepository;
        private readonly IMapper _mapper;
        public LoanItemService(ILoanItemRepository loanItemRepository, IMapper mapper) : base(loanItemRepository, mapper)
        {
            _loanItemRepository = loanItemRepository;
            _mapper = mapper;
        }
        public async Task<LoanItemCreateVM> CreateWithLoanAndProductAsync(LoanItemCreateVM loanItemCreateVM)
        {
            if(loanItemCreateVM == null) return null;
            var loanItem = _mapper.Map<LoanItem>(loanItemCreateVM);
            var createdLoanItem = await _loanItemRepository.AddAsync(loanItem);
            await _loanItemRepository.SaveChangesAsync();
            return _mapper.Map<LoanItemCreateVM>(createdLoanItem);
        }

        public async Task<IEnumerable<LoanItemVM>> GetAllWithLoanAndProductAsync()
        {
            var loanItems = await _loanItemRepository.GetAllWithLoanAndProductAsync();
            return _mapper.Map<IEnumerable<LoanItemVM>>(loanItems);
        }

        public async Task<LoanItemEditVM?> GetByIdVMWithLoanAndProductAsync(int id)
        {
            var data = await _loanItemRepository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<LoanItemEditVM>(data);
        }

        public async Task<IEnumerable<LoanItemVM>> GetLoanItemsWithProductAsync(int loanId)
        {
            if(loanId <= 0) return Enumerable.Empty<LoanItemVM>();
            var loanItems = await _loanItemRepository.GetLoanItemsWithProductAsync(loanId);
            return _mapper.Map<IEnumerable<LoanItemVM>>(loanItems);
        }

        public async Task<LoanItemVM?> GetLoanItemWithProductAsync(int id)
        {
            if(id <= 0) return null;
            var loanItem = await _loanItemRepository.GetLoanItemWithProductAsync(id);
            return loanItem != null ? _mapper.Map<LoanItemVM>(loanItem) : null;
        }

      

        public async Task<LoanItemEditVM> UpdateWithLoanAndProductAsync(LoanItemEditVM loanItemUpdateVM)
        {
            if(loanItemUpdateVM == null) return null;
            var loanItem = _mapper.Map<LoanItem>(loanItemUpdateVM);
            var updatedLoanItem = await _loanItemRepository.UpdateAsync(loanItem);
            await _loanItemRepository.SaveChangesAsync();
            return _mapper.Map<LoanItemEditVM>(updatedLoanItem);
        }
    }
}
