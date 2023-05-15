using Hangfire;
using ReminderService.Domain.Entities;
using ReminderService.Domain.Repositories;
using ReminderService.Domain.Services;

namespace ReminderService.Infrastructure.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public ReminderService(IReminderRepository reminderRepository, IBackgroundJobClient backgroundJobClient)
        {
            _reminderRepository = reminderRepository;
            _backgroundJobClient = backgroundJobClient;
        }


        public async Task<Reminder> CreateReminderAsync(Reminder reminder)
        {
            await _reminderRepository.AddAsync(reminder);
            await _reminderRepository.SaveChangesAsync();
            _backgroundJobClient.Schedule<ReminderJob>(j => j.SendReminder(reminder.Id), reminder.SendAt);
            return reminder;
        }

        public IQueryable<Reminder> GetAll()
            => _reminderRepository.GetAll();

        public async Task<Reminder> GetByIdAsync(int id)
            => await _reminderRepository.GetByIdAsync(id);

        public async Task RemoveRangeAsync(ICollection<int> reminderIds)
        {
            await _reminderRepository.RemoveRangeAsync(reminderIds);
            await _reminderRepository.SaveChangesAsync();
        }
        public async Task<bool> UpdateAsync(Reminder reminder)
        {
            var result = _reminderRepository.Update(reminder);
            await _reminderRepository.SaveChangesAsync();

            return result;
        }

    }
}
