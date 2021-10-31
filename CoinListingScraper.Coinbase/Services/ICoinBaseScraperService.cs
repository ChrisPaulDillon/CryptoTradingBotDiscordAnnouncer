
using System.Threading.Tasks;
using CoinListingScraper.Coinbase.Models;
using RestSharp;

namespace CoinListingScraper.Coinbase.Services
{
    public interface ICoinBaseScraperService
    {
        public Task<CoinBaseArticle> GetLatestCoinBaseArticle();
    }
}
