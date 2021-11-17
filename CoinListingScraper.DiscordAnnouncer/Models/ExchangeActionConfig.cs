namespace CoinListingScraper.DiscordAnnouncer.Models
{
    public class ExchangeActionConfig
    {
        public string ExchangeName { get; set; }
        public bool AutomatedSell { get; set; } = true;

        public ExchangeActionConfig(string exchangeName, bool automatedSell)
        {
            ExchangeName = exchangeName;
            AutomatedSell = automatedSell;
        }

        public ExchangeActionConfig(string exchangeName)
        {
            ExchangeName = exchangeName;
        }
    }
}
