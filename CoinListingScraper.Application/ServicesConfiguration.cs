using CoinListingScraper.Application.Queries;
using CoinListingScraper.ScraperService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScraperServices();
            services.AddMediatR(typeof(GetCoinBaseScrapeQueryHandler));

            return services;
        }
    }
}
