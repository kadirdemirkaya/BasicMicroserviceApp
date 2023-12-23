using Microsoft.Extensions.Configuration;

namespace BasicMicroserviceApp.Author.Service.Configurations
{
    public static class Configuration
    {
        public static string GetDbConnectionString
        {
            get
            {
                IConfiguration configuration = GetConfiguration();
                string conStr = configuration["DbConnectionString:DbConnection"];
                return conStr;
            }
        }

        private static IConfiguration GetConfiguration()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            return new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables()
                 .Build();
        }
    }
}
