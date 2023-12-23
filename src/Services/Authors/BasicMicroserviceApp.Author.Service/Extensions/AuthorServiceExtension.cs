using BasicMicroserviceApp.Author.Service.Abstractions;
using BasicMicroserviceApp.Author.Service.Author.Data;
using BasicMicroserviceApp.Author.Service.Services;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using BasicMicroserviceApp.BuildingBlock.Base.Configs;
using BasicMicroserviceApp.BuildingBlock.Logging;
using BasicMicroserviceApp.BuildingBlock.SqlServer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicMicroserviceApp.Author.Service.Extensions
{
    public static class AuthorServiceExtension
    {
        public static IServiceCollection AuthorServiceServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthorDbContext>(options =>
            {
                options.UseSqlServer(GetDbConnectionString(configuration),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(AssemblyReference.Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: System.TimeSpan.FromSeconds(30), null);
                });
            });

            var optionsBuilder = new DbContextOptionsBuilder<AuthorDbContext>().UseSqlServer(GetDbConnectionString(configuration));
            using var dbContext = new AuthorDbContext(optionsBuilder.Options);

            var sp = GetServiceProvider(services);

            var context = sp.GetRequiredService<AuthorDbContext>();

            services.AddScoped<IWriteRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>>(sp =>
            {
                return new WriteRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>(GetDatabaseConfig(configuration), context);
            });

            services.AddScoped<IReadRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>>(sp =>
            {
                return new ReadRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>(GetDatabaseConfig(configuration), context);
            });

            services.AddScoped<IUnitOfWork>(sp =>
            {
                return new UnitOfWork(context, GetDatabaseConfig(configuration));
            });


            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(AssemblyReference.Assembly);
            });

            services.AddMediatR(AssemblyReference.Assembly);

            services.AddScoped<IAuthorService, AuthorService>();

            return services;
        }

        public static WebApplication AuthorServiceApplicationExtension(this WebApplication app, IConfiguration configuration)
        {

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
