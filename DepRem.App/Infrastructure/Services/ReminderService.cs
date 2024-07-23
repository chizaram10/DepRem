using DepRem.App.Infrastructure.Data;
using DepRem.App.Models.DTOs;
using DepRem.App.Models.Entites;
using DepRem.App.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepRem.App.Infrastructure.Services
{
    public class ReminderService : IReminderService
    {
        private readonly AppDbContext _context;

        public ReminderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReminderListDTO>> GetAllRemindersAsync()
        {
            return await _context.Reminders
                .Select(x => new ReminderDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateTimeForExecution = x.DateTimeForExecution
                })
                .ToListAsync();
        }

        public async Task CreateReminderAsync(ReminderDTO reminderDTO)
        {
            var reminder = new Reminder
            {
                Title = reminderDTO.Title,
                DateTimeForExecution = reminderDTO.DateTimeForExecution
            };

            _context.Reminders.Add(reminder);
            await _context.SaveChangesAsync();
        }
    }
}
