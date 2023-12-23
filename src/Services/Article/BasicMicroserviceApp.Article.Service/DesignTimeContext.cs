using BasicMicroserviceApp.Article.Service.Articles.Data;
using BasicMicroserviceApp.Article.Service.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BasicMicroserviceApp.Article.Service
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<ArticleDbContext>
    {
        public ArticleDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ArticleDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetDbConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
