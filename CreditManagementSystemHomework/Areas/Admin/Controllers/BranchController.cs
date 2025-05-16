using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CreditManagementDB _db;

        public BranchController(IBranchService branchService, IWebHostEnvironment webHostEnvironment, CreditManagementDB db)
        {
            _branchService = branchService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var branch = await _branchService.GetAllAsync();
            return View(branch);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Merchant = await _db.Merchant.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BranchVM branchVM)
        {
            await _branchService.CreateAsync(branchVM);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewBag.Merchant = await _db.Merchant.ToListAsync(); 

            return View(branch);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (BranchVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _branchService.Update(model);
                return RedirectToAction("Index");
            }

            ViewBag.Merchant = await _db.Merchant.ToListAsync();
            return View(model); 
        }
        public async Task<IActionResult> Delete(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if(branch == null) return NotFound();
            return View(branch);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BranchVM branch)
        {
            await _branchService.DeleteAsync(branch.Id);   
            return RedirectToAction("Index");
        }
    }
}
