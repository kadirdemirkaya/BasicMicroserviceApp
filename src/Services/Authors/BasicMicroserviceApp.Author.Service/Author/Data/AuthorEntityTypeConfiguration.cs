using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicMicroserviceApp.Author.Service.Author.Data
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<BasicMicroserviceApp.Author.Service.Author.Models.Author>
    {
        public void Configure(EntityTypeBuilder<Models.Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.BornDate);

            builder.Property(x => x.Name);

            builder.Property(x => x.Description);

            builder.Property(x => x.Email);
        }
    }
}
