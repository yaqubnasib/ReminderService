using ReminderService.Domain.Entities;
using ReminderService.Domain.Services;
using Telegram.Bot;

namespace ReminderService.Infrastructure.Services
{
    public class TelegramReminderStrategy : IReminderStrategy
    {
        private readonly ITelegramBotClient _botClient;
        public TelegramReminderStrategy(ITelegramBotClient botClient)
        => _botClient = botClient;

        public async Task SendReminderAsync(Reminder reminder)
          => await _botClient.SendTextMessageAsync(reminder.To, reminder.Content);
    }
}
