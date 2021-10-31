using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CoinListingScraper.Application.Queries
{
    public class GetCoinBaseScrapeQuery : IRequest<bool>
    {

    }

    public class GetCoinBaseScrapeQueryHandler : IRequestHandler<GetCoinBaseScrapeQuery, bool>
    {
        public GetCoinBaseScrapeQueryHandler()
        {
           
        }

        public async Task<bool> Handle(GetCoinBaseScrapeQuery request, CancellationToken cancellationToken)
        {
            return true;
            // return await _exerciseRepo.GetAllExercises();
        }
    }
}
