using AutoMapper;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Payment;
using CreditManagementSystemHomework.Repository.Interfaces;
using CreditManagementSystemHomework.Service.Interface;

namespace CreditManagementSystemHomework.Service.Implementation
{
    public class PaymentService : GenericService<PaymentVM, Payment>, IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper) : base(paymentRepository, mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<PaymentCreateVM> CreateWithLoanAsync(PaymentCreateVM paymentCreateVM)
        {
            if(paymentCreateVM == null) return null;

            var entity = _mapper.Map<Payment>(paymentCreateVM);
            var createdEntity =await _paymentRepository.AddAsync(entity);
            await _paymentRepository.SaveChangesAsync();
            return _mapper.Map<PaymentCreateVM>(createdEntity);
        }

        public async Task<IEnumerable<PaymentVM>> GetAllWithLoansAsync()
        {
            var payments = await _paymentRepository.GetAllWithLoansAsync();
            return _mapper.Map<IEnumerable<PaymentVM>>(payments);
        }

        public async Task<PaymentUpdateVM?> GetByIdVMUpdateVMWithLoanAsync(int id)
        {
            var data = await _paymentRepository.GetByIdAsync(id);
            if (data == null) return null;
            return _mapper.Map<PaymentUpdateVM>(data);
        }

        public async Task<PaymentVM?> GetByIdWithLoanAsync(int id)
        {
            if (id <= 0) return null;

            var payment = await _paymentRepository.GetByIdWithLoanAsync(id);
            return payment != null ? _mapper.Map<PaymentVM>(payment) : null;
        }

        public async Task<IEnumerable<PaymentVM>> GetPaymentsByLoanIdAsync(int loanId)
        {
            if (loanId <= 0)
                return Enumerable.Empty<PaymentVM>();
            var payments = await _paymentRepository.GetPaymentsByLoanIdAsync(loanId);
            return _mapper.Map<IEnumerable<PaymentVM>>(payments);
        }

        public async Task<PaymentUpdateVM> UpdateWithLoanAsync(PaymentUpdateVM paymentUpdateVM)
        {
            if (paymentUpdateVM == null) return null;
            var entity = _mapper.Map<Payment>(paymentUpdateVM);
            var updatedEntity = await _paymentRepository.UpdateAsync(entity);
            await _paymentRepository.SaveChangesAsync();
            return _mapper.Map<PaymentUpdateVM>(updatedEntity);
        }
    }
}
