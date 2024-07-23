using DepRem.App.Models.DTOs;

namespace DepRem.App.Models.Interfaces
{
    public interface IReminderService
    {
        Task<IEnumerable<ReminderListDTO>> GetAllRemindersAsync();
        Task CreateReminderAsync(ReminderDTO reminderDTO);
    }
}
