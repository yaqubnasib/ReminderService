namespace ReminderService.Domain.Services
{
    public interface IReminderJob
    {
        Task SendReminder(int reminderId);
    }
}
