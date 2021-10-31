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

        public static void WriteCoinToJsonFile(CoinListing coinListing)
        {
            var coinList = new List<CoinListing> { coinListing }; //Add the list to ensure correct formatting

            var json = JsonSerializer.Serialize(coinList);
            File.WriteAllText(coinPath, json);
        }

        public static IList<CoinListing> LoadPreviouslyFoundCoins()
        {
            try
            {
                using (StreamReader r = new StreamReader(coinPath))
                {
                    string json = r.ReadToEnd();
                    var coinListings = JsonSerializer.Deserialize<List<CoinListing>>(json);
                    return coinListings;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("No coin file currently exists lmao");
                return new List<CoinListing>();
            }
        }
    }
}
