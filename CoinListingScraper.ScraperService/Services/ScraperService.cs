using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
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

        public async Task<BinanceArticle> GetLatestBinanceArticle()
        {
            Client = new RestClient(CoinBaseApiBase);
            var request = new RestRequest("composite/v1/public/cms/article/catalog/list/query?catalogId=48&pageNo=1&pageSize=15", DataFormat.Json);
            var response = await Client.GetAsync<BinanceArticle>(request);
            return response;
        }
    }
}
