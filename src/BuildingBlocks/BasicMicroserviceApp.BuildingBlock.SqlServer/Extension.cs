using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BasicMicroserviceApp.BuildingBlock.Logging;

namespace BasicMicroserviceApp.BuildingBlock.SqlServer
{
    public static class Extension
    {
        public static IServiceCollection SqlServerServiceExtension(this IServiceCollection services)
        {

            return services;
        }

        public static WebApplicationBuilder SqlServerBuilderExtension(this WebApplicationBuilder builder)
        {
            builder.AddLogSeriLogFile(
               new()
               {
                   ApplicationName = builder.Configuration["Log:ApplicationName"],
                   DefaultIndex = builder.Configuration["Log:DefaultIndex"],
                   ElasticUrl = builder.Configuration["Log:ElasticUrl"],
                   Password = builder.Configuration["Log:Password"],
                   UserName = builder.Configuration["Log:Username"]
               }, builder.Configuration);

            builder.AddFileBuilder(config =>
            {
                config.ApplicationName = builder.Configuration["Log:ApplicationName"];
                config.DefaultIndex = builder.Configuration["Log:ElasticUrl"];
                config.ElasticUrl = builder.Configuration["Log:DefaultIndex"];
                config.UserName = builder.Configuration["Log:Username"];
                config.Password = builder.Configuration["Log:Password"];
            }, builder.Configuration);

            return builder;
        }
    }
}
