using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using CoinListingScraper.ConsoleWriterService;
using CoinListingScraper.DiscordAnnouncer.Models;
using CoinListingScraper.GateIOService;
using CoinListingScraper.KuCoinService;
using CoinListingScraper.ScraperService;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Timers.Timer;

namespace CoinListingScraper.DiscordAnnouncer
{
    internal class Program
    {
        private readonly ExchangeActionConfig _kuCoinConfig = new ExchangeActionConfig("KuCoin");
        private readonly ExchangeActionConfig _binanceConfig = new ExchangeActionConfig("Binance");
        private readonly ExchangeActionConfig _coinbaseConfig = new ExchangeActionConfig("Coinbase");

        private static IDictionary<string, CoinListing> coinListings = new Dictionary<string, CoinListing>(); //Store a collection of coinListings in memory to prevent additional write operations

        private DiscordHelper _discordService;

        private IScraperService _scraperService;

        private IKuCoinService _kuCoinService;
        private IGateIoService _gateService;

        private bool isAlreadyBuying = false;

        static void Main(string[] args) => new Program().Startup().GetAwaiter().GetResult();

        public async Task Startup()
        {
            
            ConsoleWriter.WriteLine("Loading up...");
            coinListings = JsonHelper.LoadPreviouslyFoundCoins();

            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Config>()
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var myConnString = configuration.GetConnectionString("TwilioSID");

            var serviceProvider = new ServiceCollection()
                .AddScraperServices()
                .AddGateIoServices()
                .AddKuCoinServices()
                //.AddSmsServices("test", "")
                .BuildServiceProvider();

            _scraperService = serviceProvider.GetService<IScraperService>();
            _kuCoinService = serviceProvider.GetService<IKuCoinService>();
            _gateService = serviceProvider.GetService<IGateIoService>();

            _discordService = new DiscordHelper();
            await _discordService.StartBotAsync();

            ConsoleWriter.WriteLine("Discord Bot now online");
            ConsoleWriter.WriteLine("Polling every 5 seconds");

            //var timer = new Timer(TimeSpan.FromMinutes(05).TotalMilliseconds);
            var timer = new Timer(TimeSpan.FromMilliseconds(30 * 1000).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += TimerProc;
            timer.Start();
            Console.ReadLine();
            timer.Dispose();
        }

        private async Task BuyAndSellCrypto(string ticker, ExchangeActionConfig config) //new coin has been found, execute buy/sell
        {
            isAlreadyBuying = true;
            ConsoleWriter.WriteLine($"Attempting to Place Order for {ticker} at {config.ExchangeName}...");
            var orderResult = await _gateService.PlaceOrder(ticker);

            ConsoleWriter.WriteLine("Order Successfully Placed at " + DateTime.UtcNow);
            Thread.Sleep(30000); //sleep an additional 30 seconds to ensure order has been filled before proceeding

            if (config.AutomatedSell)
            {
                for (var i = 0; i < 30; i++)
                {
                    Thread.Sleep(30000);
                    ConsoleWriter.WriteLine("Checking last price...");

                    var didSell = await _gateService.AttemptSellOrder(ticker, Convert.ToDouble(orderResult.Amount), Convert.ToDouble(orderResult.Price));
                    if (!didSell) continue;

                    ConsoleWriter.WriteLine("Successfully Sold Order at " + DateTime.UtcNow);
                    break;
                }
            }
   
            ConsoleWriter.WriteLine("Continuing to poll...");
            isAlreadyBuying = false;
        }

        async void TimerProc(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (isAlreadyBuying) return;

                await PollKuCoinApi();
                await PollBinanceApi(); 
                await PollCoinBaseApi();

            }
            catch (Exception ex)
            {
                ConsoleWriter.WriteLine(ex.Message);
            }

        }

        private async Task PollKuCoinApi()
        {
            var coinListing = _scraperService.GetLatestKuCoinListing();

            if (coinListing == null) //Article did not contain a coin, continue to poll
            {
                return;
            }

            if (coinListings.TryGetValue(coinListing.Ticker, out var duplicatedCoin))
            {
                return;
            }

            coinListings.Add(coinListing.Ticker, coinListing);
            JsonHelper.WriteCoinToJsonFile(coinListings);

            var msg = $"KuCoin will list {coinListing.Name} ({coinListing.Ticker})";

            ConsoleWriter.WriteLine(msg + " at {DateTime.UtcNow}!");

            _discordService.Announce(msg); //There is no need for buying/selling to wait for the discord action

            await BuyAndSellCrypto(coinListing.Ticker, _kuCoinConfig);
        }

        private async Task PollBinanceApi()
        {
            var coinListing = await _scraperService.GetLatestBinanceArticle();

            if (coinListing == null) //Article did not contain a coin, continue to poll
            {
                return;
            }

            if (coinListings.TryGetValue(coinListing.Ticker, out var duplicatedCoin))
            {
                return;
            }

            coinListings.Add(coinListing.Ticker, coinListing);
            JsonHelper.WriteCoinToJsonFile(coinListings);

            var msg = coinListing?.Ticker == null ? $"Binance will list {coinListing.Name}" : $"Binance will list {coinListing.Name} ({coinListing.Ticker})";

            ConsoleWriter.WriteLine(msg + $" at {DateTime.UtcNow}!");

            _discordService.Announce(msg); //There is no need for buying/selling to wait for the discord action

            await BuyAndSellCrypto(coinListing.Ticker, _binanceConfig);
        }

        private async Task PollCoinBaseApi()
        {
            ConsoleWriter.WriteLine("Polling CoinBase API...");
            var coinListingList = await _scraperService.GetLatestCoinBaseArticle();

            foreach (var listing in coinListingList)
            {
                if (coinListings.TryGetValue(listing, out var duplicatedCoin))
                {
                    return;
                }

                var coinListing = new CoinListing() { Ticker = listing };
                coinListings.Add(coinListing.Ticker, coinListing);

                JsonHelper.WriteCoinToJsonFile(coinListings);

                var msg = $"CoinBase will list {coinListing.Ticker}";
                ConsoleWriter.WriteLine(msg + $" at {DateTime.UtcNow}!");

                _discordService.Announce(msg); //There is no need for buying/selling to wait for the discord action

                await BuyAndSellCrypto(coinListing.Ticker, _coinbaseConfig);
            }
        }
    }
}
