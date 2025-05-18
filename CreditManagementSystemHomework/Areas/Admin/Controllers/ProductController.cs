using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Entities;
using CreditManagementSystemHomework.Models.Product;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly CreditManagementDB _context;

        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment, CreditManagementDB creditManagementDB)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
            _context = creditManagementDB;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllWithCategoryAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add([FromForm]ProductCreateVM model)
        {
            if (model.Image != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var extension = Path.GetExtension(model.Image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Only (.jpg, .jpeg, .png, .gif, .webp) files are allowed.");
                }

                if (model.Image.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "File size must be 5 MB or less.");
                }

                if (!model.Image.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("Image", "File must be an image.");
                }
            }

            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync();
                model.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

                return View(model);
            }

            await _productService.CreateWithImageAsync(model);
            TempData["Success"] = "Product created successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetUpdateVMByIdAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Product not found.";
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditVM product)
        {
            if (product.Image != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
                var extension = Path.GetExtension(product.Image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Only (.jpg, .jpeg, .png, .gif, .webp) files are allowed.");
                }

                if (product.Image.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Image", "File size must be 5 MB or less.");
                }

                if (!product.Image.ContentType.StartsWith("image/"))
                {
                    ModelState.AddModelError("Image", "File must be an image.");
                }
            }

            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllAsync();
                product.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            }

            await _productService.UpdateWithImageAsync(product);
            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                TempData["Error"] = "Product not found.";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            await _productService.DeleteWithImageAsync(id);
            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
