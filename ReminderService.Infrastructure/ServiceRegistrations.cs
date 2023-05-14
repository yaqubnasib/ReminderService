using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using ReminderService.Application;
using ReminderService.Domain.Services;
using ReminderService.Infrastructure.Factories;
using ReminderService.Infrastructure.Services;
using Telegram.Bot;

namespace ReminderService.Infrastructure
{
    public static class ServiceRegistrations
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITelegramBotClient>(x => new TelegramBotClient(Config.TelegramBotToken));
            services.AddHangfire(config => config.UsePostgreSqlStorage(Config.ReminderConnectionString));
            services.AddHangfireServer();
            services.AddScoped<IReminderService, Services.ReminderService>();
            services.AddScoped<IReminderJob, ReminderJob>();
            services.AddScoped<TelegramReminderStrategy>();
            services.AddScoped<EmailReminderStrategy>();
            services.AddScoped<IReminderStrategyFactory, ReminderStrategyFactory>();

        }
    }
}
