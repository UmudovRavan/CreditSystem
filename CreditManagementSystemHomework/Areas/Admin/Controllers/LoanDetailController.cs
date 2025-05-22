using CreditManagementSystemHomework.Models.LoanDetail;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoanDetailController : Controller
    {
        private readonly ILoanDetailService _loanDetailService;
        private readonly ILoanService _loanService;
        public LoanDetailController(ILoanDetailService loanDetailService, ILoanService loanService)
        {
            _loanDetailService = loanDetailService;
            _loanService = loanService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var deatils = await _loanDetailService.GetAllWithLoansAsync();
            return View(deatils);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var loans = await _loanService.GetAllAsync();
            var model = new LoanDetailCreateVM
            {
                Loans = loans.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CustomerName
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanDetailCreateVM loanDetailCreateVM)
        {
            if (!ModelState.IsValid)
            {
                var loans = await _loanService.GetAllAsync();
                loanDetailCreateVM.Loans = loans.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CustomerName
                }).ToList();
                return View(loanDetailCreateVM);
            }
            await _loanDetailService.CreateWithLoansAsync(loanDetailCreateVM);
            TempData["Succes"] = "LoanDetail created successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var detail = await _loanDetailService.GetByIdVMWithLoansAndPaymentsAsync(id);
            if (detail == null)
            {
                TempData["Error"] = "LoanDetail not found.";
                return NotFound();
            }

            var loans = await _loanService.GetAllAsync();
            detail.Loans = loans.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CustomerName
            }).ToList();

            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LoanDetailEditVM loanDetailEditVM)
        {
            if (!ModelState.IsValid)
            {
                var loans = await _loanService.GetAllAsync();
                loanDetailEditVM.Loans = loans.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CustomerName
                }).ToList();
                return View(loanDetailEditVM);
            }
            await _loanDetailService.UpdateWithLoansAsync(loanDetailEditVM);
            TempData["Succes"] = "LoanDetail updated successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var detail = await _loanDetailService.GetByIdWithLoansAsync(id);
            if (detail == null)
            {
                TempData["Error"] = "LoanDetail not found."; return NotFound();
            }
            return View(detail);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _loanDetailService.DeleteAsync(id);
            TempData["Succes"] = "LoanDetail deleted successfully";
            return RedirectToAction("Index");
        }
    }
}