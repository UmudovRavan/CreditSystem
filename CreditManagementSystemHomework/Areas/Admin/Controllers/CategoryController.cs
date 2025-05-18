using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _categoryService;
        public CategoryController(IWebHostEnvironment env, ICategoryService categoryService)
        {
            _env = env;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories  = await _categoryService.GetAllAsync();
            return View(categories);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete (CategoryVM categoryVM)
        {
            await _categoryService.DeleteAsync(categoryVM.Id);
            return RedirectToAction("Index");
        }
    }
}
