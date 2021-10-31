using CoinListingScraper.Data.Entities;
using RestSharp;

namespace CoinListingScraper.Binance
{
    public static class BinanceHelper
    {
        private const string BinanceApiBase = "https://www.binance.com/bapi/";
        private static readonly RestClient Client = new RestClient(BinanceApiBase);

        public static IRestResponse<Root> GetArticlesRequest()
        {
            var request = new RestRequest("composite/v1/public/cms/article/catalog/list/query?catalogId=48&pageNo=1&pageSize=15", DataFormat.Json);
            var response = Client.Get<Root>(request);
            return response;
        }
    }
}
