using System.Threading.Tasks;

namespace CoinListingScraper.GateIOService
{
    public interface IGateIoService
    {
        public Task PlaceOrder(string tokenTicker);
    }
}
