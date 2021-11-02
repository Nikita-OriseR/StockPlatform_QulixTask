using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockPlatform.Domain;
namespace StockPlatform.Persistance.EntityTypeConfigurations
{
    class StockPlatformConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author => author.AuthorId);
            builder.HasIndex(author => author.AuthorId).IsUnique();
        }
    }
}
