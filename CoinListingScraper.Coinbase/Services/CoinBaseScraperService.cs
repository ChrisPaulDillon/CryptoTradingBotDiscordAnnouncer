using System;
using System.Threading.Tasks;
using CoinListingScraper.Coinbase.Models;
using RestSharp;

namespace CoinListingScraper.Coinbase.Services
{
    public class CoinBaseScraperService : ICoinBaseScraperService
    {
        private const string BinanceApiBase = "https://medium.com/_/api/";
        private static readonly RestClient Client = new RestClient(BinanceApiBase);

        public async Task<CoinBaseArticle> GetLatestCoinBaseArticle()
        {
            var request = new RestRequest("collections/c114225aeaf7/latest", DataFormat.Json);
            var response = await Client.GetAsync<CoinBaseArticle>(request);
            return response;
        }
    }
}
