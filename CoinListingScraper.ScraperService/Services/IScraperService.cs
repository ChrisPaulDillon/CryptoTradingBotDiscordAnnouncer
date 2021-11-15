using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
using System.Collections.Generic;

namespace CoinListingScraper.ScraperService.Services
{
    public interface IScraperService
    {
        public CoinListing GetLatestKuCoinListing();
        public Task<IEnumerable<string>> GetLatestCoinBaseArticle();
        public Task<CoinListing> GetLatestBinanceArticle();
    }
}
