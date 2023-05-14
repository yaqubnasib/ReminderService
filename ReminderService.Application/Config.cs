using Microsoft.Extensions.Configuration;

namespace ReminderService.Application
{
    public static class Config
    {
        public static string ReminderConnectionString
        {
            get
            {
                ConfigurationManager configurationManger = new();

                configurationManger.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ReminderService.API"));
                configurationManger.AddJsonFile("appsettings.json");

                return configurationManger?.GetConnectionString("pgSqlLocal");
            }
        }
    }
}
