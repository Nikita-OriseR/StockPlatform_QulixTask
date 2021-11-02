using Microsoft.EntityFrameworkCore;
using StockPlatform.Application.Interfaces;
using StockPlatform.Domain;
using StockPlatform.Persistance.EntityTypeConfigurations;

namespace StockPlatform.Persistance
{
    public class StockPlatformDbContext : DbContext, IStockPlatformDbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }

        public StockPlatformDbContext(DbContextOptions<StockPlatformDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StockPlatformConfiguration());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
