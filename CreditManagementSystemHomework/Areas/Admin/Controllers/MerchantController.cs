using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MerchantController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMerchantService _merchantService;

        public MerchantController(IWebHostEnvironment webHostEnvironment,IMerchantService merchantService)
        {
            _webHostEnvironment = webHostEnvironment;
            _merchantService = merchantService;
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await _merchantService.GetAllAsync();
            return View(merchants);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MerchantVM model)
        {
            if (ModelState.IsValid)
            {
                await _merchantService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var merchant =  await _merchantService.GetByIdAsync(id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MerchantVM model)
        {
            if (ModelState.IsValid)
            {
                await _merchantService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var merchant = await _merchantService.GetByIdAsync(id);
            if(merchant == null) return NotFound();
            return View(merchant);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MerchantVM merchant)
        {
            await _merchantService.DeleteAsync(merchant.Id);
            return RedirectToAction("Index");
        }
    }
}
