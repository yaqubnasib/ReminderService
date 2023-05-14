using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReminderService.Application.Contexts;
using ReminderService.Application.Repositories;
using ReminderService.Application.Validators;
using ReminderService.Domain.Repositories;

namespace ReminderService.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<ReminderContext>(options => options.UseNpgsql(Config.ReminderConnectionString));
            services.AddSingleton<IReminderRepository, ReminderRepository>();
            services.AddValidatorsFromAssemblyContaining<ReminderValidator>();
        }
    }
}
