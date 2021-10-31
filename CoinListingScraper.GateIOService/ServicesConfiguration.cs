using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.GateIOService
{
    public static class ServicesConfiguration
    {
        private const string API_BASE = "https://api.gateio.ws/api/v4";

        public static IServiceCollection AddGateIoServices(this IServiceCollection services, string apiKeyStr, string secretStr)
        {
           

            var config = new Configuration();
            config.BasePath = API_BASE;
            config.SetGateApiV4KeyPair(apiKeyStr, secretStr);

            SpotApi spotApi; = new SpotApi(config);
            services.AddScoped<IGateIOService, GateIOService>();

            return services;
        }
    }
}
