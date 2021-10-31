using CoinListingScraper.ScraperService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.ScraperService
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddScraperServices(this IServiceCollection services)
        {
            services.AddScoped<IScraperService, Services.ScraperService>();

            return services;
        }
    }
}
