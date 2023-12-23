using BasicMicroserviceApp.Article.Service.Articles.Data;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using BasicMicroserviceApp.BuildingBlock.Base.Configs;
using BasicMicroserviceApp.BuildingBlock.Logging;
using BasicMicroserviceApp.BuildingBlock.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicMicroserviceApp.Article.Service.Extensions
{
    public static class ArticleServiceExtension
    {
        public static IServiceCollection ArticleServiceServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArticleDbContext>(options =>
            {
                options.UseSqlServer(GetDbConnectionString(configuration),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(AssemblyReference.Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: System.TimeSpan.FromSeconds(30), null);
                });
            });

            var optionsBuilder = new DbContextOptionsBuilder<ArticleDbContext>().UseSqlServer(GetDbConnectionString(configuration));
            using var dbContext = new ArticleDbContext(optionsBuilder.Options);

            var sp = GetServiceProvider(services);

            var context = sp.GetRequiredService<ArticleDbContext>();

            services.AddScoped<IWriteRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>>(sp =>
            {
                return new WriteRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>(GetDatabaseConfig(configuration), context);
            });

            services.AddScoped<IReadRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>>(sp =>
            {
                return new ReadRepository<BasicMicroserviceApp.Article.Service.Articles.Models.Article>(GetDatabaseConfig(configuration), context);
            });

            services.AddScoped<IUnitOfWork>(sp =>
            {
                return new UnitOfWork(context, GetDatabaseConfig(configuration));
            });

            services.AddGrpc();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AssemblyReference.Assembly);
            });

            services.AddMediatR(AssemblyReference.Assembly);


            return services;
        }

        public static WebApplication ArticleServiceApplicationExtension(this WebApplication app, IConfiguration configuration)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BasicMicroserviceApp.Article.Service.Services.Grpc.ArticleService>();

                endpoints.MapGet("/Protos/article.proto", async context =>
                {
                    await context.Response.WriteAsync(File.ReadAllText("Protos/article.proto"));
                });
            });

            return app;
        }

        public static WebApplicationBuilder ArticleServiceBuilderExtension(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.AddLogSeriLogFile(
                GetLogConfig(configuration), configuration);

            builder.AddFileBuilder(config =>
            {
                config.ApplicationName = configuration["Log:ApplicationName"];
                config.DefaultIndex = configuration["Log:ElasticUrl"];
                config.ElasticUrl = configuration["Log:DefaultIndex"];
                config.UserName = configuration["Log:Username"];
                config.Password = configuration["Log:Password"];
            }, configuration);

            return builder;
        }

        private static LogConfig GetLogConfig(IConfiguration configuration)
          => new()
          {
              ApplicationName = configuration["Log:ApplicationName"],
              DefaultIndex = configuration["Log:DefaultIndex"],
              ElasticUrl = configuration["Log:ElasticUrl"],
              Password = configuration["Log:Password"],
              UserName = configuration["Log:Username"]
          };

        private static InMemoryConfig GetInMemoryConfig(IConfiguration configuration)
            => new()
            {
                Connection = configuration["DbConnection"],
                RetryCount = int.Parse(configuration["DbConnectionString:RetryCount"]),
                Username = configuration["Username"] ?? string.Empty,
                Password = configuration["Password"] ?? string.Empty
            };

        private static DatabaseConfig GetDatabaseConfig(IConfiguration configuration)
             => new()
             {
                 ConnectionString = configuration["DbConnection"],
                 RetryCount = int.Parse(configuration["DbConnectionString:RetryCount"]),
             };

        private static string GetDbConnectionString(IConfiguration configuration)
         => configuration["DbConnection"];

        private static ServiceProvider GetServiceProvider(IServiceCollection services) => services.BuildServiceProvider();
    }
}
