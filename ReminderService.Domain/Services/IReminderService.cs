using ReminderService.Domain.Entities;

namespace ReminderService.Domain.Services
{
    public interface IReminderService
    {
        Task<Reminder> CreateReminderAsync(Reminder reminder);
        Task<ICollection<Reminder>> GetAllAsync();
        Task<Reminder> GetByIdAsync(int id);
        bool Update(Reminder reminder);
        void RemoveRange(IEnumerable<Reminder> reminders);

    }
}
