using CoinListingScraper.CoinGecko;
using System;
using System.Text.RegularExpressions;
using CoinListingScraper.ScraperService.Models;

namespace CoinListingScraper.ScraperService.Util
{
    public static class ResultParser
    {
        public static CoinListing ExtractCoinFromKuCoinArticle(string articleTitle)
        {
            var listStr = " Gets Listed ";
            if (!articleTitle.Contains(listStr)) //Only continue if the article is about listing a new coin
            {
                //Console.WriteLine($"Latest Article is not a coin listing: {articleTitle}");
                return null;
            }

            var beforeListedText = articleTitle.Substring(0, articleTitle.IndexOf(")") + 1).Trim();  //Get the text before "Gets Listed"
            var tokenName = beforeListedText.Substring(0, beforeListedText.IndexOf("(")).Trim();
            var ticker = Regex.Match(beforeListedText, @"\(([^)]*)\)").Groups[1].Value; //Get ticker in brackets if available

            var coinListing = new CoinListing()
            {
                Name = tokenName,
                Ticker = ticker,
            };

            return coinListing;
        }

        public static CoinListing ExtractCoinFromBinanceArticle(string articleTitle)
        {
            var listStr = " List ";

            if (!articleTitle.Contains(listStr)) //Only continue if the article is about listing a new coin
            {
                //Console.WriteLine($"Latest Article is not a coin listing: {articleTitle}");
                return null;
            }

            var afterListStr = articleTitle.Substring(articleTitle.IndexOf(listStr) + listStr.Length).Trim(); //Get the text after "list"
            //var listOfWords = afterListStr.Split(' ');

            var tokenName = afterListStr.Substring(0, afterListStr.IndexOf("(")).Trim();
            //var tokenName = listOfWords[0]; //Get the name of token straight after the word 'List'
            var ticker = Regex.Match(afterListStr, @"\(([^)]*)\)").Groups[1].Value; //Get ticker in brackets if available

            var coinListing = new CoinListing()
            {
                Name = tokenName,
                Ticker = ticker,
            };

            return coinListing;
        }
    }
}
