using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;
using CoinListingScraper.GateIOService;
using CoinListingScraper.KuCoinService;
using CoinListingScraper.ScraperService;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinListingScraper.DiscordAnnouncer
{
    internal class Program
    {
        private static IDictionary<string, CoinListing> coinListings = new Dictionary<string, CoinListing>(); //Store a collection of coinListings in memory to prevent additional write operations

        private DiscordHelper _discordService;

        private IScraperService _scraperService;

        private IKuCoinService _kuCoinService;
        private IGateIoService _gateService;

        private Stopwatch _stopWatch;

        static void Main(string[] args) => new Program().Startup().GetAwaiter().GetResult();

        public async Task Startup()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();

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
            //_gateService = new GateIOService();

            //_gateService.GetCurrency();
            await _discordService.StartBotAsync();

            Console.WriteLine(_stopWatch.Elapsed + "Discord Bot now online");

            Console.WriteLine(_stopWatch.Elapsed + "Polling every 60 seconds.");
            await _gateService.PlaceOrder("CHESS");
            var timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += TimerProc;
            timer.Start();

                        _gateService.PlaceOrder("CHESS");
            Console.ReadLine();
            timer.Dispose();
        }

        async void TimerProc(object sender, ElapsedEventArgs e)
        {
            try
            {
    
                //await _kuCoinService.PlaceOrder("MOVR");
                //await PollBinanceApi();
                //await PollCoinBaseApi();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private async Task PollBinanceApi()
        {
            Console.WriteLine(_stopWatch.Elapsed + "Polling Binance API...");
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
            Console.WriteLine(_stopWatch.Elapsed + "Polling CoinBase API...");
            var coinListingList = await _scraperService.GetLatestCoinBaseArticle();

            foreach (var listing in coinListingList)
            {
                if (coinListings.TryGetValue(listing, out var duplicatedCoin))
                {
                    //Console.WriteLine("Coin found has already been stored");
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
