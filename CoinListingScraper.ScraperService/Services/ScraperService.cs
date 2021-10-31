using System;
using System.Linq;
using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Util;
using RestSharp;

namespace CoinListingScraper.ScraperService.Services
{
    public class ScraperService : IScraperService
    {
        private const string BinanceApiBase = "https://www.binance.com/bapi/";
        private const string CoinBaseApiBase = "https://medium.com/_/api/";

        private RestClient Client = new RestClient(BinanceApiBase);

        public async Task<CoinBaseArticle> GetLatestCoinBaseArticle()
        {
            Client = new RestClient(BinanceApiBase);
            var request = new RestRequest("collections/c114225aeaf7/latest", DataFormat.Json);
            var response = await Client.GetAsync<CoinBaseArticle>(request);
            return response;
        }

        public async Task<CoinListing> GetLatestBinanceArticle()
        {
            Client = new RestClient(CoinBaseApiBase);
            var request = new RestRequest("composite/v1/public/cms/article/catalog/list/query?catalogId=48&pageNo=1&pageSize=15", DataFormat.Json);
            var response = await Client.GetAsync<BinanceArticle>(request);

            var latestArticle = response.data.articles.Where(x => x.title.Contains("List")).Select(x => x.title).FirstOrDefault(); //Get the latest article title
            var coinListing = ResultParser.ExtractCoinFromBinanceArticle(latestArticle);

            if (coinListing != null) //Found a new coin listing, write to disk
            {
                //var coinInCollection = coinListings.Any(x => x.Name == coinListing.Name);
                //if (coinInCollection)
                //{
                //    Console.WriteLine("Coin found has already been stored");
                //    return;
                //}

                //JsonHelper.WriteCoinToJsonFile(coinListing);
                //coinListings.Add(coinListing);
                var msg = coinListing?.Ticker == null ? $"Binance will list {coinListing.Name}!" : $"Binance will list {coinListing.Name} ({coinListing.Ticker})!";
                Console.WriteLine(msg);
                //await _discordService.Announce(msg);
                return coinListing;
            }

            Console.WriteLine("No new coin found, trying again in 60 seconds");
            return null;
        }
    }
}
