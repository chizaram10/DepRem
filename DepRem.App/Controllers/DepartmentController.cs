using DepRem.App.Models.Interfaces;
using DepRem.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepRem.App.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Departments";

            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var departmentDTO = await _departmentService.GetDepartmentByIdAsync(id);
            if (departmentDTO == null)
            {
                return NotFound();
            }

            ViewData["Title"] = $"Department - {departmentDTO.Name}";

            return View(departmentDTO);
        }

        // GET: Department/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = "Create Department";

            var parentDepartments = await _departmentService.GetAllDepartmentsAsync();
            var viewModel = new DepartmentViewModel
            {
                ParentDepartments = parentDepartments.ToList()
            };
            return View(viewModel);
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.CreateDepartmentAsync(viewModel.Department);
                return RedirectToAction(nameof(Index));
            }

            viewModel.ParentDepartments = (await _departmentService.GetAllDepartmentsAsync()).ToList();
            return View(viewModel);
        }
    }
}
