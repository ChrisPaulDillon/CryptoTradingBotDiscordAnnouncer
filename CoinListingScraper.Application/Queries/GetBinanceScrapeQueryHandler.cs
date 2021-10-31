using System.Threading;
using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using MediatR;

namespace CoinListingScraper.Application.Queries
{
    public class GetBinanceScrapeQuery : IRequest<CoinListing>
    {

    }

    public class GetBinanceScrapeQueryHandler : IRequestHandler<GetBinanceScrapeQuery, CoinListing>
    {
        private readonly IScraperService _scraperService;

        public GetBinanceScrapeQueryHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        public async Task<CoinListing> Handle(GetBinanceScrapeQuery request, CancellationToken cancellationToken)
        {
            var result = await _scraperService.GetLatestBinanceArticle();
            return result;
        }
    }
}
