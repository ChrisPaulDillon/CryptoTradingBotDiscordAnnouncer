using CoinListingScraper.CoinGecko.Models;
using RestSharp;

namespace CoinListingScraper.CoinGecko
{
    public static class CoinGeckoHelper
    {
        private static readonly string BASE_API = "https://api.coingecko.com/api/v3/";
        private static readonly RestClient client = new RestClient(BASE_API);

        public static string GetCoinTicker(string coinName)
        {
            var request = new RestRequest($"coins/{coinName}", DataFormat.Json);
            var response = client.Get<CoinGeckoToken>(request);
            return response.Data.symbol;
        }
    }
}
