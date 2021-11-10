using CoinListingScraper.CoinGecko;
using System;
using System.Text.RegularExpressions;
using CoinListingScraper.ScraperService.Models;

namespace CoinListingScraper.ScraperService.Util
{
    public static class ResultParser
    {
        public static CoinListing ExtractCoinFromBinanceArticle(string articleTitle)
        {
            if (!articleTitle.Contains("List")) //Only continue if the article is about listing a new coin
            {
                Console.WriteLine($"Latest Article is not a coin listing: {articleTitle}");
                return null;
            }

            var listStr = " List ";
            var afterListStr = articleTitle.Substring(articleTitle.IndexOf(listStr) + listStr.Length).Trim(); //Get the text after "list"
            //var listOfWords = afterListStr.Split(' ');

            var tokenName = afterListStr.Substring(0, afterListStr.IndexOf("(")).Trim();
            //var tokenName = listOfWords[0]; //Get the name of token straight after the word 'List'
            var ticker = Regex.Match(afterListStr, @"\(([^)]*)\)").Groups[1].Value; //Get ticker in brackets if available

            //if (string.IsNullOrEmpty(ticker)) //The original API request could not get the ticker, attempt to get it from coingecko
            //{
            //    ticker = CoinGeckoHelper.GetCoinTicker(tokenName.ToLower());
            //    ticker = ticker.ToUpper();
            //}

            var coinListing = new CoinListing()
            {
                Name = tokenName,
                Ticker = ticker,
            };

            return coinListing;
        }
    }
}
