using Microsoft.AspNetCore.Builder;

namespace BasicMicroserviceApp.BuildingBlock.Logging
{

    public static class ServiceExtension
    {
        public static WebApplicationBuilder AddFileBuilder(this WebApplicationBuilder app, Action<LogConfig> configure, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var elasticConfiguration = new LogConfig();
            configure(elasticConfiguration);

            app.AddLogSeriLogFile(elasticConfiguration, configuration);

            return app;
        }
    }
}
