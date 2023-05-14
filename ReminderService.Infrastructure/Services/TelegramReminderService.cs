using ReminderService.Domain.Entities;
using ReminderService.Domain.Services;

namespace ReminderService.Infrastructure.Services
{
    public class TelegramReminderService : IReminderStrategy
    {
        public Task SendReminderAsync(Reminder reminder)
        {
            throw new NotImplementedException();
        }
    }
}
