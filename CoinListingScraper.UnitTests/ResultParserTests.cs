using CoinListingScraper.ScraperService.Util;
using Xunit;

namespace CoinListingScraper.UnitTests
{
    public class ResultParserTests
    {
        [Fact]
        public void ExtractCoinFromBinanceArticle_TextDoesNotContainList_ReturnsNull()
        {
            // arrange
            var articleText = "test lmao rofl";

            // act
            var result = ResultParser.ExtractCoinFromBinanceArticle(articleText);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void ExtractCoinFromBinanceArticle_TextContainsListInWord_ReturnsNull()
        {
            // arrange
            var articleText = "listless test";

            // act
            var result = ResultParser.ExtractCoinFromBinanceArticle(articleText);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void ExtractCoinFromBinanceArticle_TextContainsListAndTicker_ReturnsCoinListing()
        {
            // arrange
            var articleText = "Binance Will List Tranchess (CHESS) in the Innovation Zone";

            // act
            var result = ResultParser.ExtractCoinFromBinanceArticle(articleText);

            // assert
            Assert.Equal("Tranchess", result.Name);
            Assert.Equal("CHESS", result.Ticker);
        }

        [Fact]
        public void ExtractCoinFromBinanceArticle_TextContainsNameMultipleWords_ReturnsCoinListing()
        {
            // arrange
            var coinToBeListed = "Ethereum Name Service";
            var ticker = "ETH";
            var articleText = $"Binance Will List {coinToBeListed} ({ticker}) Innovation Zone";

            // act
            var result = ResultParser.ExtractCoinFromBinanceArticle(articleText);

            // assert
            Assert.Equal(coinToBeListed, result.Name);
            Assert.Equal(ticker, result.Ticker);
        }
    }
}
