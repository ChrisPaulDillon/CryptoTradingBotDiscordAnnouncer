using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.GateIOService
{
    public static class ServicesConfiguration
    {
        private const string API_BASE = "https://api.gateio.ws/api/v4";

        public static IServiceCollection AddGateIoServices(this IServiceCollection services)
        {
            var config = new Configuration();
            config.BasePath = API_BASE;
            config.SetGateApiV4KeyPair("64416ae784ac0d0fbcd93aaa662749cb", "2c884a787626f3d482fae0b64d980a451477956fe53784ee4dfd55a60dc4f99f");

            var spotApi = new SpotApi(config);
            var walletApi = new WalletApi(config);

            services.AddScoped<IGateIoService>(src => new GateIoService(spotApi, walletApi));
            return services;
        }
    }
}
