using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Util;
using RestSharp;

namespace CoinListingScraper.ScraperService.Services
{
    public class ScraperService : IScraperService
    {
        private const string BinanceApiBase = "https://www.binance.com/bapi/";
        private const string CoinBaseApi = "https://medium.com/_/api/collections/c114225aeaf7/latest";

        private RestClient _client = new RestClient(BinanceApiBase);

        public async Task<IEnumerable<string>> GetLatestCoinBaseArticle()
        {
            Console.WriteLine("Calling GetLatestCoinBaseArticle()");
            var client = new WebClient();
            var downloadString = client.DownloadString(CoinBaseApi);

            var result = downloadString.Split()
                .Where(x => x.StartsWith("(") && x.EndsWith(")") && x.ToUpper() == x)
                .GroupBy(x => x)
                .Select(x => x.First().Remove(0, 1).Remove(x.First().Length - 2, 1))
                .ToList();

            return result;
        }

        public CoinListing GetLatestKuCoinListing()
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create("https://www.kucoin.com/rss/news?lang=en"))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch { } // TODO: Deal with unavailable resource.

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    var coinListing = ResultParser.ExtractCoinFromKuCoinArticle(element.Title.Text);
                    if (coinListing != null)
                    {
                        return coinListing;
                    }
                }
            }

            return null;
        }

        public async Task<CoinListing> GetLatestBinanceArticle()
        {
            _client = new RestClient(BinanceApiBase);
            var request = new RestRequest("composite/v1/public/cms/article/catalog/list/query?catalogId=48&pageNo=1&pageSize=10", DataFormat.Json);
            var response = await _client.GetAsync<BinanceArticle>(request);

            var latestArticle = response.data.articles.FirstOrDefault().title;

            Console.WriteLine(latestArticle);

            if (!latestArticle.Contains(" List "))
            {
                return null;
            }
            var coinListing = ResultParser.ExtractCoinFromBinanceArticle(latestArticle);

            if (coinListing != null) //Found a new coin listing, write to disk
            {
                return coinListing;
            }

            return null;
        }
    }
}
