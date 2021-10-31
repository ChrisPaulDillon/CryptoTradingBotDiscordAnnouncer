using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using CoinListingScraper.ScraperService.Models;
using CoinListingScraper.ScraperService.Services;
using MediatR;
using System.Collections.Generic;

namespace CoinListingScraper.Application.Queries
{
    public class GetCoinBaseScrapeQuery : IRequest<IEnumerable<string>>
    {

    }

    public class GetCoinBaseScrapeQueryHandler : IRequestHandler<GetCoinBaseScrapeQuery, IEnumerable<string>>
    {
        private readonly IScraperService _scraperService;

        public GetCoinBaseScrapeQueryHandler(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }

        public async Task<IEnumerable<string>> Handle(GetCoinBaseScrapeQuery request, CancellationToken cancellationToken)
        {
            var result = await _scraperService.GetLatestCoinBaseArticle();
            return result;
        }
    }
}
