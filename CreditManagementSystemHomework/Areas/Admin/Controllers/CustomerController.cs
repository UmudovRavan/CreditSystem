using CreditManagementSystemHomework.Models.Customer;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllWithLoansAsync();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateVM customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            await _customerService.CreateWithLoansAsync(customer);
            TempData["Success"] = "Customer created successfully!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdVMUpdateVMWithLoansAsync(id);
            if (customer == null)
            {
                TempData["Error"] = "Customer not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerEditVM customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            await _customerService.UpdateWithLoansAsync(customer);
            TempData["Success"] = "Customer updated successfully!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                TempData["Error"] = "Customer not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _customerService.DeleteAsync(id);
            TempData["Success"] = "Customer deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
