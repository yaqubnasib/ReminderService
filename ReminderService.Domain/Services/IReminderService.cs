using ReminderService.Domain.Entities;

namespace ReminderService.Domain.Services
{
    public interface IReminderService
    {
        Task<Reminder> CreateReminderAsync(Reminder reminder);
        IQueryable<Reminder> GetAll();
        Task<Reminder> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Reminder reminder);
        Task RemoveRangeAsync(ICollection<int> reminderIds);

    }
}
