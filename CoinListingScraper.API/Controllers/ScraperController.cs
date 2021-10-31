using System.Threading.Tasks;
using CoinListingScraper.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoinListingScraper.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScraperController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ScraperController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CoinBase")]
        public async Task<IActionResult> GetCoinBaseLatestListing()
        {
            var coinBaseArticle = await _mediator.Send(new GetCoinBaseScrapeQuery());
            return Ok(coinBaseArticle);
        }

        [HttpGet("Binance")]
        public async Task<IActionResult> GetBinanceLatestListing()
        {
            var coinBaseArticle = await _mediator.Send(new GetBinanceScrapeQuery());
            return Ok(coinBaseArticle);
        }
    }
}
