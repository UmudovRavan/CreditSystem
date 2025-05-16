using CreditManagementSystemHomework.Data;
using CreditManagementSystemHomework.Models;
using CreditManagementSystemHomework.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementSystemHomework.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly CreditManagementDB _dB;
        private readonly IWebHostEnvironment _environment;
        public EmployeeController(IEmployeeService employeeService,CreditManagementDB dB,IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _dB = dB;
            _environment = environment; 
        }
        public async Task<IActionResult> Index()
        {
            var employee = await _employeeService.GetAllAsync();
            return View(employee);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Branches = await _dB.Branches.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM model)
        {
            await _employeeService.CreateAsync(model);  
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id); 
            if (employee == null)
            {
                return NotFound();
            }
            ViewBag.Branches = await _employeeService.GetAllAsync();
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeVM model)
        {
            if(ModelState.IsValid)
            {
                var result = await _employeeService.Update(model);
                return RedirectToAction("Index");
            }
            ViewBag.Branches = await _dB.Branches.ToListAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id); 
            return RedirectToAction("Index");
        }
    }
}
