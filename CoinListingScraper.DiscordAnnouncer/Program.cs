using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinListingScraper.ScraperService;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.DiscordAnnouncer
{
    internal class Program
    {
        private static IDictionary<string, CoinListing> coinListings = new Dictionary<string, CoinListing>(); //Store a collection of coinListings in memory to prevent additional write operations

        private DiscordHelper _discordService;

        private IScraperService _scraperService;
        //private GateIOService _gateService;

        static void Main(string[] args) => new Program().Startup().GetAwaiter().GetResult();

        public async Task Startup()
        {
            Console.WriteLine("Loading up...");
            coinListings = JsonHelper.LoadPreviouslyFoundCoins();

            var serviceProvider = new ServiceCollection()
                .AddScraperServices()
                .BuildServiceProvider();

           _scraperService = serviceProvider.GetService<IScraperService>();

           _discordService = new DiscordHelper();
            //_gateService = new GateIOService();

            //_gateService.GetCurrency();
            await _discordService.StartBotAsync();

            Console.WriteLine("Discord Bot now online");

            var timer = new System.Threading.Timer(TimerProc, null, 6000, 6000);
            Console.WriteLine("Polling every 60 seconds.");
            Console.ReadLine();
            timer.Dispose();
        }

        async void TimerProc(object state)
        {
            Console.WriteLine("Polling Binance API...");
            await PollBinanceApi();
            Console.WriteLine("Polling CoinBase API...");
            await PollCoinBaseApi();
        }

        private async Task PollBinanceApi()
        {
            var coinListing = await _scraperService.GetLatestBinanceArticle();
            
            if(coinListings.TryGetValue(coinListing.Ticker, out var duplicatedCoin))
            {
                return;
            }

            coinListings.Add(coinListing.Ticker, coinListing);
            JsonHelper.WriteCoinToJsonFile(coinListings);

            var msg = coinListing?.Ticker == null ? $"Binance will list {coinListing.Name}!" : $"Binance will list {coinListing.Name} ({coinListing.Ticker})!";
            Console.WriteLine(msg);
            await _discordService.Announce(msg);
        }

        private async Task PollCoinBaseApi()
        {
            var coinListingList = await _scraperService.GetLatestCoinBaseArticle();

            foreach (var listing in coinListingList)
            {
                if (coinListings.TryGetValue(listing, out var duplicatedCoin))
                {
                    Console.WriteLine("Coin found has already been stored");
                    return;
                }

                var coinListing = new CoinListing() { Ticker = listing };
                coinListings.Add(coinListing.Ticker, coinListing);

                JsonHelper.WriteCoinToJsonFile(coinListings);
  
                var msg = $"CoinBase will list {coinListing.Ticker}!";
                Console.WriteLine(msg);
                await _discordService.Announce(msg);
            }
        }
    }
}
