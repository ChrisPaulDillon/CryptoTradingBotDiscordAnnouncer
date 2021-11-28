using System;
using System.Threading.Tasks;
using CoinListingScraper.ConsoleWriterService;
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

        public async Task CancelSpotBuyOrder(string tokenTicker)
        {
            try
            {
                var tokenPair = $"{tokenTicker}_USDT";
                // Cancel all `open` orders in specified currency pair
                var result = await _spotApi.CancelOrdersAsync(tokenPair, "buy", "spot");
            }
            catch (ApiException e)
            {
                throw e;
            }
        }

        public async Task<Order> PlaceOrder(string tokenTicker)
        {
            try
            {
                var tokenPair = $"{tokenTicker}_USDT";
                var currencyPair = await _spotApi.GetCurrencyPairAsync(tokenPair);
                var userTotalBalance = await _walletApi.GetTotalBalanceAsync();
                var orderBook = await _spotApi.ListTickersAsync(tokenPair);

                var userBalance = Convert.ToDouble(userTotalBalance.Total.Amount);

                if(userBalance < 5)
                {
                    ConsoleWriter.WriteLineNegative("User balance is too low, will not buy");
                    return null;
                }

                var lastPrice = Convert.ToDouble(orderBook[0].Last) * 1.001; //Ensure coin is actually bought by buying slightly over the last price

                var amountToBuy = RoundDown((Convert.ToDouble(userBalance) - 5) / lastPrice, 2);

                ConsoleWriter.WriteLine("");
                ConsoleWriter.WriteLinePositive($"User Balance : ${userBalance}");
                ConsoleWriter.WriteLinePositive($"Last Price : ${orderBook[0].Last}");
                ConsoleWriter.WriteLinePositive($"Buying Price: ${lastPrice}");
                ConsoleWriter.WriteLinePositive($"Amount of {tokenTicker} to buy: " + amountToBuy);

                var order = new Order(null, tokenPair, Order.TypeEnum.Limit, Order.AccountEnum.Spot, Order.SideEnum.Buy, amountToBuy.ToString(), lastPrice.ToString());

                var createdOrder = await _spotApi.CreateOrderAsync(order);
                ConsoleWriter.WriteLine("");
                ConsoleWriter.WriteLinePositive($"Created order Amount of token : {createdOrder.Amount}");
                ConsoleWriter.WriteLinePositive($"Attempting to buy {tokenTicker} at : ${createdOrder.Price}" );

                return createdOrder;
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AttemptSellOrder(string tokenTicker, double amountToSell, double boughtPrice)
        {
            try
            {
                ConsoleWriter.WriteLine("");

                var tokenPair = $"{tokenTicker}_USDT";

                var orderBook = await _spotApi.ListTickersAsync(tokenPair);
                var lastPrice = Convert.ToDouble(orderBook[0].Last);

                var howMuchIncreased = (lastPrice - boughtPrice) / boughtPrice * 100;
                if (howMuchIncreased < 10) //Coin is not currently above 10% of what we bought, don't buy it
                {
                    ConsoleWriter.WriteLineNegative($"Current price (${lastPrice}) is {RoundDown(howMuchIncreased, 2)}% relative to the original buying price, do not sell");
                    return false;
                }

                var amountToSellUpdated = amountToSell * 0.997; //Temporary until just read wallet balance of token

                ConsoleWriter.WriteLineNegative($"Amount of {tokenTicker} to sell: " + amountToSellUpdated);
                ConsoleWriter.WriteLineNegative("Selling at Price: $" + lastPrice);

                var priceToSell = lastPrice * 0.999; //Sell slightly lower than last price to ensure the sale
                var order = new Order(null, tokenPair, Order.TypeEnum.Limit, Order.AccountEnum.Spot, Order.SideEnum.Sell, amountToSellUpdated.ToString(), priceToSell.ToString());
                await _spotApi.CreateOrderAsync(order);
                return true;
            }
            catch (ApiException ex)
            {
                throw ex;
            }
        }
    }
}
