using BasicMicroserviceApp.Author.Service.Author.Data;
using BasicMicroserviceApp.Author.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BasicMicroserviceApp.Author.Service
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<AuthorDbContext>
    {
        public AuthorDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AuthorDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetDbConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
