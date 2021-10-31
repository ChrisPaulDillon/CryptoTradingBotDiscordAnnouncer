using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;

namespace CoinListingScraper.ScraperService.Services
{
    public interface IScraperService
    {
        public Task<CoinBaseArticle> GetLatestCoinBaseArticle();
        public Task<CoinListing> GetLatestBinanceArticle();
    }
}
