using CoinListingScraper.Coinbase.Models;
using RestSharp;

namespace CoinListingScraper.Coinbase
{
    public static class CoinBaseHelper
    {
        private const string BinanceApiBase = "https://medium.com/_/api/";
        private static readonly RestClient Client = new RestClient(BinanceApiBase);

        public static IRestResponse<CoinBaseArticle> GetArticlesRequest()
        {
            var request = new RestRequest("collections/c114225aeaf7/latest", DataFormat.Json);
            var response = Client.Get<CoinBaseArticle>(request);
            return response;
        }
    }
}
