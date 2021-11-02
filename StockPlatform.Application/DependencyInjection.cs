using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StockPlatform.Application.Common.Behaviors;
using System.Reflection;

namespace StockPlatform.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
