using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace BasicMicroserviceApp.BuildingBlock.Logging
{
    public static class LogExtension
    {
        public static WebApplicationBuilder AddLogSeriLogFile(this WebApplicationBuilder builder, LogConfig config, IConfiguration configuration)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .MinimumLevel.Override("MassTransit", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("ApplicationName", $"{config.ApplicationName}")
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                .WriteTo.Async(writeTo => writeTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Serilog.Log.Logger, true);

            return builder;
        }
    }
}
