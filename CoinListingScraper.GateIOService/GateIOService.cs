using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Io.Gate.GateApi.Model;

namespace CoinListingScraper.GateIOService
{
    public class GateIOService : IGateIOService
    {
        private readonly SpotApi _spotApi;
        
        public GateIOService(SpotApi spotApi)
        {
            _spotApi = spotApi;
        }

        public void PlaceOrder(string tokenTicker)
        {
            try
            {
                var tokenPair = $"{tokenTicker}_USDT";
                var result = _spotApi.GetCurrencyPair(tokenPair);
                var order = new Order();
                order.CurrencyPair = tokenPair;
            }
            catch (GateApiException)
            {
                
            }
        }
    }
}
