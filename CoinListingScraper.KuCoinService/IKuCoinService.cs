using System.Threading.Tasks;

namespace CoinListingScraper.KuCoinService
{
    public interface IKuCoinService
    {
        Task PlaceOrder(string tokenTicker);
    }
}
