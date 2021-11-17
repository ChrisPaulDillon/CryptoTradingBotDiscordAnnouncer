using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        private readonly ExchangeActionConfig _kuCoinConfig = new ExchangeActionConfig("KuCoin", false);
        private readonly ExchangeActionConfig _binanceConfig = new ExchangeActionConfig("Binance");
        private static IDictionary<string, CoinListing> coinListings = new Dictionary<string, CoinListing>(); //Store a collection of coinListings in memory to prevent additional write operations

        private DiscordHelper _discordService;

        private IScraperService _scraperService;

        private IKuCoinService _kuCoinService;
        private IGateIoService _gateService;

        private bool isAlreadyBuying = false;

        static void Main(string[] args) => new Program().Startup().GetAwaiter().GetResult();

        public async Task Startup()
        {
            Console.WriteLine("Loading up...");
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

            Console.WriteLine("Discord Bot now online");
            Console.WriteLine("Polling every 580 ms");

            //var timer = new Timer(TimeSpan.FromMinutes(05).TotalMilliseconds);
            var timer = new Timer(TimeSpan.FromMilliseconds(580).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += TimerProc;
            timer.Start();
            Console.ReadLine();
            timer.Dispose();
        }

        private async Task BuyAndSellCrypto(string ticker, ExchangeActionConfig config) //new coin has been found, execute buy/sell
        {
            isAlreadyBuying = true;
            Console.WriteLine("Attempting to Place Order...");
            var amountToSell = await _gateService.PlaceOrder(ticker);

            Console.WriteLine("Order Successfully Placed at " + DateTime.UtcNow);
            if (config.AutomatedSell)
            {
                Console.WriteLine("Going to sleep for 5 minutes");

                Thread.Sleep(300000);
                await _gateService.SellOrder(ticker, amountToSell);
                Console.WriteLine("Successfully Sold Order at " + DateTime.UtcNow);
            }
   
            isAlreadyBuying = false;
        }

        async void TimerProc(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (isAlreadyBuying) return;

                await PollKuCoinApi();
                await PollBinanceApi(); 
                //await PollCoinBaseApi();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private async Task PollKuCoinApi()
        {
            var coinListing = _scraperService.GetLatestKuCoinListing();

            if (coinListings.TryGetValue(coinListing.Ticker, out var duplicatedCoin))
            {
                return;
            }

            coinListings.Add(coinListing.Ticker, coinListing);

            JsonHelper.WriteCoinToJsonFile(coinListings);

            var msg = $"KuCoin will list {coinListing.Name} ({coinListing.Ticker})!";
            Console.WriteLine(msg);
            await _discordService.Announce(msg);

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

            var msg = coinListing?.Ticker == null ? $"Binance will list {coinListing.Name}!" : $"Binance will list {coinListing.Name} ({coinListing.Ticker})!";
            Console.WriteLine(msg);
            await _discordService.Announce(msg);

            await BuyAndSellCrypto(coinListing.Ticker, _binanceConfig);
        }

        private async Task PollCoinBaseApi()
        {
            Console.WriteLine("Polling CoinBase API...");
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

                var msg = $"CoinBase will list {coinListing.Ticker}!";
                Console.WriteLine(msg);
                await _discordService.Announce(msg);

                //await BuyAndSellCrypto(coinListing.Ticker);
            }
        }
    }
}
