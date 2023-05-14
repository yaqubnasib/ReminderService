using Microsoft.Extensions.Configuration;

namespace ReminderService.Application
{
    public static class Config
    {
        public static string ReminderConnectionString
        {
            get
            {
                ConfigurationManager configurationManger = ConfigureInternalServices();
                return configurationManger?.GetConnectionString("pgSqlLocal");
            }
        }

        public static string TelegramBotToken
        {
            get
            {
                ConfigurationManager configurationManger = ConfigureInternalServices();
                return configurationManger["TelegramBotToken"];
            }
        }


        private static ConfigurationManager ConfigureInternalServices()
        {
            ConfigurationManager configurationManger = new();

            configurationManger.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ReminderService.API"));
            configurationManger.AddJsonFile("appsettings.json");

            return configurationManger;
        }
    }
}
