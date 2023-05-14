using Microsoft.Extensions.DependencyInjection;
using ReminderService.Domain.Services;
using ReminderService.Domain.Utils;
using ReminderService.Infrastructure.Services;

namespace ReminderService.Infrastructure.Factories
{
    public interface IReminderStrategyFactory
    {
        IReminderStrategy CreateStrategy(string method);
    }

    public class ReminderStrategyFactory : IReminderStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ReminderStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IReminderStrategy CreateStrategy(string method)
        {
            return method switch
            {
                StrategyConstants.TelegramStrategy => _serviceProvider.GetRequiredService<TelegramReminderStrategy>(),
                StrategyConstants.EmailStrategy => _serviceProvider.GetRequiredService<EmailReminderStrategy>(),
                _ => throw new ArgumentException($"Invalid reminder method: {method}", nameof(method))
            };
        }
    }
}
