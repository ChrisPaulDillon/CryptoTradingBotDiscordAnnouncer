using System.Threading;
using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using MediatR;

namespace CoinListingScraper.Application.Queries
{
    public class GetCoinBaseScrapeQuery : IRequest<CoinBaseArticle>
    {

    }

    public class GetCoinBaseScrapeQueryHandler : IRequestHandler<GetCoinBaseScrapeQuery, CoinBaseArticle>
    {
        private readonly IScraperService _scraperService;

        public GetCoinBaseScrapeQueryHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        public async Task<CoinBaseArticle> Handle(GetCoinBaseScrapeQuery request, CancellationToken cancellationToken)
        {
            var result = await _scraperService.GetLatestCoinBaseArticle();
            return result;
        }
    }
}
