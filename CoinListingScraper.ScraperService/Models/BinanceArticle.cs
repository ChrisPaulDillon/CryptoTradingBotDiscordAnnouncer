using System;
using System.Collections.Generic;
using System.Text;

namespace CoinListingScraper.ScraperService.Models
{
    public class Article
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public object body { get; set; }
        public object type { get; set; }
        public object catalogId { get; set; }
        public object catalogName { get; set; }
        public object publishDate { get; set; }
    }

    public class Data
    {
        public List<Article> articles { get; set; }
        public int total { get; set; }
    }

    public class BinanceArticle
    {
        public string code { get; set; }
        public object message { get; set; }
        public object messageDetail { get; set; }
        public Data data { get; set; }
        public bool success { get; set; }
    }
}
