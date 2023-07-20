using UnityEngine;

namespace Plinko
{
    public class CoinManager : BasePlugObject
    {
        [SerializeField]
        private Coin _coinPrefab;

        private GridItem _headItem;

        private Money _money;

        private PoolObjects<Coin> _poolCoins;

        private int _bet = 10;

        public void Init(GridItem headItem, Money money)
        {
            _headItem = headItem;
            _money = money;

            _poolCoins = new PoolObjects<Coin>(_coinPrefab, 40, transform);
            _poolCoins.AutoExpand = true;
        }

        public void SellCoin(int color)
        {
            Coin coin = _poolCoins.GetFreeElement();
            _money.RemoveMoney(_bet);
            coin.Init(_headItem, (ColorContainer)color, _money, _bet);
        }
    }

    public enum ColorContainer
    {
        green, orange, red
    }
}
