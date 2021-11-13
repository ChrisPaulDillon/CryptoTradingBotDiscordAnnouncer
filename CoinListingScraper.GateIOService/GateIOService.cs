using System;
using System.Threading.Tasks;
using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Io.Gate.GateApi.Model;

namespace CoinListingScraper.GateIOService
{
    public class GateIoService : IGateIoService
    {
        private readonly SpotApi _spotApi;
        private readonly WalletApi _walletApi;

        public GateIoService(SpotApi spotApi, WalletApi walletApi)
        {
            _spotApi = spotApi;
            _walletApi = walletApi;
        }

        public async Task PlaceOrder(string tokenTicker)
        {
            try
            {
                var tokenPair = $"{tokenTicker}_USDT";
                var result = await _spotApi.GetCurrencyPairAsync(tokenPair);
                var test = await _walletApi.GetTotalBalanceAsync();
                Console.WriteLine(test);
                Console.WriteLine(result);
                var order = new Order();
                order.CurrencyPair = tokenPair;
                //order.Account = Order.AccountEnum.Spot;
                //order.
            }
            catch (GateApiException ex)
            {
                throw ex;
            }
        }
    }
}
