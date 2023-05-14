using ReminderService.Domain.Entities;

namespace ReminderService.Domain.Services
{
    public interface IReminderService
    {
        Reminder CreateReminder(Reminder reminder);
    }
}
