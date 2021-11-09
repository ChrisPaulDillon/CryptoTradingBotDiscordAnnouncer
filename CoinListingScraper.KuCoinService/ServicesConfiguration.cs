using Kucoin.Net;
using Kucoin.Net.Interfaces;
using Kucoin.Net.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.KuCoinService
{
    public static class ServicesConfiguration
    {

        public static IServiceCollection AddKuCoinServices(this IServiceCollection services)
        {

            services.AddScoped<IKucoinClient>(srv => new KucoinClient(new KucoinClientOptions()
            {
                ApiCredentials = new KucoinApiCredentials("618adf023c39ca0001c8648c", "55759fed-7605-4bb3-8dbb-3a781a3f3526", "Animal1995@")
            }));

            services.AddScoped<IKuCoinService, KuCoinService>();

            return services;
        }
    }
}
