using UnityEngine;

namespace Plinko
{
    public abstract class BaseColorContainer : MonoBehaviour
    {
        [SerializeField]
        protected CoinContainer[] _coinContainer;

        public CoinContainer GetContainer(int index)
        {
            return _coinContainer[index];
        }
    }
}
