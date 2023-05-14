using ReminderService.Domain.Entities;
using ReminderService.Domain.Services;
using System.Net.Mail;

namespace ReminderService.Infrastructure.Services
{
    public class EmailReminderStrategy : IReminderStrategy
    {
        private readonly SmtpClient _smtpClient;

        public EmailReminderStrategy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendReminderAsync(Reminder reminder)
        {
            MailMessage mailMessage = new("", reminder.To, "Reminder", reminder.Content);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
