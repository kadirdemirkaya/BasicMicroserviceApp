using Microsoft.EntityFrameworkCore;

namespace BasicMicroserviceApp.Author.Service.Author.Data
{
    public class AuthorDbContext : DbContext
    {
        protected AuthorDbContext()
        {
        }

        public AuthorDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BasicMicroserviceApp.Author.Service.Author.Models.Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
