using System.Threading.Tasks;

namespace CoinListingScraper.GateIOService
{
    public interface IGateIoService
    {
        public Task CancelSpotBuyOrder(string tokenTicker);
        public Task<string> PlaceOrder(string tokenTicker);
        public Task SellOrder(string tokenTicker, string amountToSell);
    }
}
