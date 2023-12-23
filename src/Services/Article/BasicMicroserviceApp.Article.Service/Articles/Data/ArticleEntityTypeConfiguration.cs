using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicMicroserviceApp.Article.Service.Articles.Data
{
    public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<BasicMicroserviceApp.Article.Service.Articles.Models.Article>
    {
        public void Configure(EntityTypeBuilder<Models.Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Content);

            builder.Property(x => x.Title);

            builder.Property(x => x.AuthorId);
        }
    }
}
