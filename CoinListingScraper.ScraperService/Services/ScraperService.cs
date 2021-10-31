using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        private RestClient _client = new RestClient(BinanceApiBase);

        public async Task<IEnumerable<string>> GetLatestCoinBaseArticle()
        {
            var client = new WebClient();
            var downloadString = client.DownloadString("https://medium.com/_/api/collections/c114225aeaf7/latest");
            //string code = downloadString.Substring(42);
            //var codeSecondRemoved = code.Substring(0, code.Length - 32);
            //var article = JsonConvert.DeserializeObject<CoinBaseArticle>(codeSecondRemoved);
            var result = downloadString.Split()
                .Where(x => x.StartsWith("(") && x.EndsWith(")"))
                .GroupBy(x => x)
                .Select(x => x.First().Remove(0, 1).Remove(x.First().Length - 2, 1))
                .ToList();

            return result;
        }

        public async Task<CoinListing> GetLatestBinanceArticle()
        {
            _client = new RestClient(BinanceApiBase);
            var request = new RestRequest("composite/v1/public/cms/article/catalog/list/query?catalogId=48&pageNo=1&pageSize=15", DataFormat.Json);
            var response = await _client.GetAsync<BinanceArticle>(request);

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
                //Console.WriteLine(msg);
                //await _discordService.Announce(msg);
                return coinListing;
            }

            //Console.WriteLine("No new coin found, trying again in 60 seconds");
            return null;
        }
    }
}
