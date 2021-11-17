using System.Threading.Tasks;
using Io.Gate.GateApi.Model;

namespace CoinListingScraper.GateIOService
{
    public interface IGateIoService
    {
        public Task CancelSpotBuyOrder(string tokenTicker);
        public Task<Order> PlaceOrder(string tokenTicker);
        public Task<bool> AttemptSellOrder(string tokenTicker, double amountToSell, double price);
    }
}
