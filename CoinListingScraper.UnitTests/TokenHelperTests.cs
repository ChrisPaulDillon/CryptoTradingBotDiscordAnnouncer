using CoinListingScraper.Binance;
using Xunit;

namespace CoinListingScraper.UnitTests
{
    public class TokenHelperTests
    {
        [Fact]
        public void ExtractCoinFromArticle_TextDoesNotContainList_ReturnsNull()
        {
            // arrange
            var articleText = "test lmao rofl";

            // act
            var result = TokenHelper.ExtractCoinFromArticle(articleText);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void ExtractCoinFromArticle_TextContainsListInWord_ReturnsNull()
        {
            // arrange
            var articleText = "listless test";

            // act
            var result = TokenHelper.ExtractCoinFromArticle(articleText);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void ExtractCoinFromArticle_TextContainsListAndTicker_ReturnsCoinListing()
        {
            // arrange
            var articleText = "Binance Will List Tranchess (CHESS) in the Innovation Zone";

            // act
            var result = TokenHelper.ExtractCoinFromArticle(articleText);

            // assert
            Assert.Equal("Tranchess", result.Name);
            Assert.Equal("CHESS", result.Ticker);
        }

        [Fact]
        public void ExtractCoinFromArticle_TextContainsJustName_ReturnsCoinListing()
        {
            // arrange
            var articleText = "Binance Will List Tranchess Innovation Zone";

            // act
            var result = TokenHelper.ExtractCoinFromArticle(articleText);

            // assert
            Assert.Equal("Tranchess", result.Name);
            Assert.Equal("CHESS", result.Ticker);
        }
    }
}
