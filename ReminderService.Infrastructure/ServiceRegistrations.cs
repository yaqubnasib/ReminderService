using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using ReminderService.Application;
using ReminderService.Domain.Services;
using ReminderService.Infrastructure.Services;
using Telegram.Bot;

namespace ReminderService.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITelegramBotClient>(x => new TelegramBotClient(Config.TelegramBotToken));
            services.AddHangfire(config => config.UsePostgreSqlStorage(Config.ReminderConnectionString));
            services.AddHangfireServer();
            services.AddSingleton<IReminderService, Services.ReminderService>();
            services.AddSingleton<IReminderJob, ReminderJob>();
            services.AddSingleton<TelegramReminderStrategy>();
            services.AddSingleton<EmailReminderStrategy>();

        }
    }
}
