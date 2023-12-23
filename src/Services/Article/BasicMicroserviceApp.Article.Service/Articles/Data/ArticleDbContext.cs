using Microsoft.EntityFrameworkCore;

namespace BasicMicroserviceApp.Article.Service.Articles.Data
{
    public class ArticleDbContext : DbContext
    {
        protected ArticleDbContext()
        {
        }
        public ArticleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BasicMicroserviceApp.Article.Service.Articles.Models.Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
