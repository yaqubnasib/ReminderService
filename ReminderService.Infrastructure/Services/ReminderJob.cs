using ReminderService.Domain.Repositories;
using ReminderService.Domain.Services;
using ReminderService.Infrastructure.Factories;

namespace ReminderService.Infrastructure.Services
{
    public class ReminderJob : IReminderJob
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IReminderStrategyFactory _reminderStrategyFactory;

        public ReminderJob(IReminderRepository reminderRepository, IReminderStrategyFactory reminderStrategyFactory)
        {
            _reminderRepository = reminderRepository;
            _reminderStrategyFactory = reminderStrategyFactory;
        }

        public async Task SendReminder(int reminderId)
        {
            var reminder = await _reminderRepository.GetByIdAsync(reminderId);
            var strategy = _reminderStrategyFactory.CreateStrategy(reminder.Method);

            await strategy.SendReminderAsync(reminder);
            reminder.Sent = true;

            _reminderRepository.Update(reminder);
            await _reminderRepository.SaveChangesAsync();
        }
    }
}
