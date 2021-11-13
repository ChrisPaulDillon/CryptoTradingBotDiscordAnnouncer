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

        public double RoundDown(double number, int decimalPlaces)
        {
            return Math.Floor(number * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
        }

        public async Task PlaceOrder(string tokenTicker)
        {
            try
            {
                var tokenPair = $"{tokenTicker}_USDT";
                var currencyPair = await _spotApi.GetCurrencyPairAsync(tokenPair);
                var userBalance = await _walletApi.GetTotalBalanceAsync();
                var orderBook = await _spotApi.ListTickersAsync(tokenPair);

                var lastPrice = orderBook[0].Last;

                var amountToBuy = Convert.ToDouble(userBalance.Total.Amount) / Convert.ToDouble(lastPrice);

                Console.WriteLine("User Balance :" + userBalance.Total.Amount);
                Console.WriteLine("Last Price: " + orderBook[0].Last);
                Console.WriteLine($"Amount of : {tokenTicker} to buy: " + amountToBuy);

                var order = new Order(null, tokenPair, Order.TypeEnum.Limit, Order.AccountEnum.Spot, Order.SideEnum.Buy, RoundDown(amountToBuy, 2).ToString(), lastPrice);

                Console.WriteLine(order);
                var createdOrder = await _spotApi.CreateOrderAsync(order);
                Console.WriteLine(createdOrder);
            }
            catch (GateApiException ex)
            {
                throw ex;
            }
        }
    }
}
