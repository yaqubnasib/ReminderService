using ReminderService.Domain.Entities;

namespace ReminderService.Domain.Services
{
    public interface IReminderStrategy
    {
        Task SendReminderAsync(Reminder reminder);
    }
}
