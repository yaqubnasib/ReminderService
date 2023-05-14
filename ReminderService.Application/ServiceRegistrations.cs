using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReminderService.Application.Contexts;

namespace ReminderService.Application
{
    public static class ServiceRegistrations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<ReminderContext>(options => options.UseNpgsql(Config.ReminderConnectionString));
        }
    }
}
