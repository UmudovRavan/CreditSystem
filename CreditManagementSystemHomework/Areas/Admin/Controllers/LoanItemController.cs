using CreditManagementSystemHomework.Models.LoanItem;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoanItemController : Controller
    {
        private readonly ILoanItemService _loanItemService;
        private readonly ILoanService _loanService;
        private readonly IProductService _productService;
        public LoanItemController(ILoanItemService loanItemService, ILoanService loanService, IProductService productService)
        {
            _loanItemService = loanItemService;
            _loanService = loanService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var loanItems = await _loanItemService.GetAllWithLoanAndProductAsync();
            return View(loanItems);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var loans = await _loanService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            var models = new LoanItemCreateVM
            {
                Loans = loans.Select(loans => new SelectListItem
                {
                    Value = loans.Id.ToString(),
                    Text = loans.CustomerName
                }).ToList(),
                Products = products.Select(products => new SelectListItem
                {
                    Value = products.Id.ToString(),
                    Text = products.Name
                }).ToList()
            };
            TempData["Error"] = "Please correct the errors in the form.";
            return View(models);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoanItemCreateVM loanItemCreateVM)
        {
            if (!ModelState.IsValid)
            {
                var loans = await _loanService.GetAllAsync();
                var products = await _productService.GetAllAsync();
                loanItemCreateVM.Loans = loans.Select(loans => new SelectListItem
                {
                    Value = loans.Id.ToString(),
                    Text = loans.CustomerName
                }).ToList();
                loanItemCreateVM.Products = products.Select(products => new SelectListItem
                {
                    Value = products.Id.ToString(),
                    Text = products.Name
                }).ToList();

                return View(loanItemCreateVM);
            }
            await _loanItemService.CreateWithLoanAndProductAsync(loanItemCreateVM);
            TempData["Success"] = "Loan item created successfully.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var loanItem = await _loanItemService.GetByIdVMWithLoanAndProductAsync(id);

            if (loanItem == null) return NotFound();

            var loans = await _loanService.GetAllAsync();
            var products = await _productService.GetAllAsync();

            loanItem.Loans = loans.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.CustomerName
            }).ToList();

            loanItem.Products = products.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            }).ToList();

            return View(loanItem);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LoanItemEditVM loanItemEditVM)
        {
            if (!ModelState.IsValid)
            {
                var loans = await _loanService.GetAllAsync();
                var products = await _productService.GetAllAsync();
                loanItemEditVM.Loans = loans.Select(loans => new SelectListItem
                {
                    Value = loans.Id.ToString(),
                    Text = loans.CustomerName
                }).ToList();
                loanItemEditVM.Products = products.Select(products => new SelectListItem
                {
                    Value = products.Id.ToString(),
                    Text = products.Name
                }).ToList();

                return View(loanItemEditVM);
            }
            await _loanItemService.UpdateWithLoanAndProductAsync(loanItemEditVM);
            TempData["Success"] = "Loan item updated successfully.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var loanItem = await _loanItemService.GetLoanItemWithProductAsync(id);
            if (loanItem == null) { TempData["Error"] = "Loan item not found."; return NotFound(); }
            return View(loanItem);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {   
            await _loanItemService.DeleteAsync(id);
            TempData["Success"] = "Loan item deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
