using CreditManagementSystemHomework.Models.Loan;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        public LoanController(ILoanService loanService, ICustomerService customerService, IEmployeeService employeeService)
        {
            _loanService = loanService;
            _customerService = customerService;
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var loans = await _loanService.GetLoansWithCustomerAndEmployeeAsync();
            return View(loans);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var employees = await _employeeService.GetAllAsync();
            var customers = await _customerService.GetAllAsync();

            var model = new LoanCreateVM
            {
                Employees = employees.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList(),
                Customers = customers.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanCreateVM loan)
        {
            if (!ModelState.IsValid)
            {
                var employees = await _employeeService.GetAllAsync();
                var customers = await _customerService.GetAllAsync();

                loan.Employees = employees.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList();

                loan.Customers = customers.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList();

                return View(loan);
            }

            await _loanService.CreateVMAsync(loan);
            TempData["Success"] = "Loan created successfully!";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var loan = await _loanService.GetLoanUpdateVMByCustomerIdAsync(id);
            if (loan == null)
            {
                TempData["Error"] = "Loan not found.";
                return RedirectToAction(nameof(Index));
            }

            var employees = await _employeeService.GetAllAsync();
            var customers = await _customerService.GetAllAsync();

            loan.Employees = employees.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.FullName
            }).ToList();

            loan.Customers = customers.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.FullName
            }).ToList();

            return View(loan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LoanEditVM loan)
        {
            if (!ModelState.IsValid)
            {
                var employees = await _employeeService.GetAllAsync();
                var customers = await _customerService.GetAllAsync();

                loan.Employees = employees.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList();

                loan.Customers = customers.Select(m => new SelectListItem
                {
                    Value = m.Id.ToString(),
                    Text = m.FullName
                }).ToList();

                return View(loan);
            }

            await _loanService.UpdateVMAsync(loan);
            TempData["Success"] = "Loan updated successfully!";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _loanService.GetByIdAsync(id);
            if (loan == null)
            {
                TempData["Error"] = "Loan not found.";
                return RedirectToAction(nameof(Index));
            }

            return View(loan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _loanService.DeleteAsync(id);
            TempData["Success"] = "Loan deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
