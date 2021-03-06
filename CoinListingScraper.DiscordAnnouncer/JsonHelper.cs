using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CoinListingScraper.ScraperService.Models;

namespace CoinListingScraper.DiscordAnnouncer
{
    internal class JsonHelper
    {
        private static string coinPath = Path.Combine(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName, "coins.json");

        public static void WriteCoinToJsonFile(IDictionary<string, CoinListing> coinListings)
        {
            var json = JsonSerializer.Serialize(coinListings);
            File.WriteAllText(coinPath, json);
        }

        public static IDictionary<string, CoinListing> LoadPreviouslyFoundCoins()
        {
            if (File.Exists(coinPath))
            {
                 using (StreamReader r = new StreamReader(coinPath))
                 {
                    string json = r.ReadToEnd();
                    var coinListings = JsonSerializer.Deserialize<Dictionary<string, CoinListing>>(json);
                    return coinListings;
                 }
            }

           Console.WriteLine("No coin file currently exists lmao");
           return new Dictionary<string, CoinListing>();
        }
    }
}
