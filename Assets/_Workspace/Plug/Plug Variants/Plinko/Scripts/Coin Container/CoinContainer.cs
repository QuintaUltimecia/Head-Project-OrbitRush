using UnityEngine;

namespace Plinko
{
    public class CoinContainer : MonoBehaviour
    {
        [field: SerializeField]
        public float Multiplier { get; private set; }
    }

}