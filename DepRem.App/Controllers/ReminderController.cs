using DepRem.App.Models.DTOs;
using DepRem.App.Models.Entites;
using DepRem.App.Models.Interfaces;
using DepRem.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepRem.App.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IReminderService _reminderService;

        public ReminderController(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        // GET: Reminder
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "All Reminders";

            var reminders = await _reminderService.GetAllRemindersAsync();
            return View(reminders);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Reminder";

            return View(new ReminderDTO());
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReminderDTO reminderDTO)
        {
            if (ModelState.IsValid)
            {
                await _reminderService.CreateReminderAsync(reminderDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(new ReminderDTO());
        }
    }
}
