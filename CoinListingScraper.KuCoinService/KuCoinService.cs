using System;
using System.Linq;
using System.Threading.Tasks;
using Kucoin.Net.Interfaces;
using Kucoin.Net.Objects;

namespace CoinListingScraper.KuCoinService
{
    public class KuCoinService : IKuCoinService
    {
        private readonly IKucoinClient _client;

        public KuCoinService(IKucoinClient client)
        {
            _client = client;
        }

        public async Task PlaceOrder(string tokenTicker)
        {
            var callResult = await _client.Spot.GetCurrencyAsync(tokenTicker); //Check token exists
            // Make sure to check if the call was successful

            if (!callResult.Success)
            {
                Console.WriteLine(callResult.Error);
                return; //handle proper failure
            }
            else
            {
                var test = await _client.Spot.GetUserInfoAsync();
                var data = test.Data;
                //var test = await _client.Spot.GetAccountAsync()
                var buyResult = await _client.Spot.PlaceOrderAsync($"{tokenTicker}-USDT", null, KucoinOrderSide.Buy, KucoinNewOrderType.Market, quantity: 1, price: null, timeInForce: KucoinTimeInForce.GoodTillCancelled);
                if (buyResult.Success)
                {
                    Console.WriteLine("Successfully bought crypto!");
                }
                else
                {
                    Console.WriteLine("Failed to buy crypto something has went wrong");
                }
  
            }
        }
    }
}
