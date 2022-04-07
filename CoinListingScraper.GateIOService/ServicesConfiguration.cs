using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.GateIOService
{
    public static class ServicesConfiguration
    {
        private const string API_BASE = "https://api.gateio.ws/api/v4";
        private const string GATE_IO_SECRET = "";
        private const string GATE_IO_KEY = "";

        public static IServiceCollection AddGateIoServices(this IServiceCollection services)
        {
            var config = new Configuration();
            config.BasePath = API_BASE;
            config.SetGateApiV4KeyPair(GATE_IO_SECRET, GATE_IO_KEY);

            var spotApi = new SpotApi(config);
            var walletApi = new WalletApi(config);

            services.AddScoped<IGateIoService>(src => new GateIoService(spotApi, walletApi));
            return services;
        }
    }
}
