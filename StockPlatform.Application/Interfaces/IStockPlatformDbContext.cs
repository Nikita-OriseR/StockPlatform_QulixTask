using Microsoft.EntityFrameworkCore;
using StockPlatform.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace StockPlatform.Application.Interfaces
{
    public interface IStockPlatformDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Text> Texts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
