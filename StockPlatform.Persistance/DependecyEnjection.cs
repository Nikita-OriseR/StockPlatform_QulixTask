using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockPlatform.Application.Interfaces;

namespace StockPlatform.Persistance
{
    public static class DependecyEnjection
    {
        public static IServiceCollection AddPersistense(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration[$"Data Source = localhost; Initial Catalog = {nameof(StockPlatformDbContext)}; Integrated Security = True"];
            services.AddDbContext<StockPlatformDbContext>(options =>
           {
               options.UseSqlServer(connectionString);
           });
            services.AddScoped<IStockPlatformDbContext>(provider => provider.GetService<StockPlatformDbContext>());
            return services;
        }
    }
}
