using UnityEngine;

namespace Plinko
{
    public class GridItem : MonoBehaviour
    {
        [field: SerializeField]
        public int ID { get; private set; }

        [field: SerializeField]
        public AllCoinContainers AllCoinContainers { get; private set; }

        [field: SerializeField]
        public GridItem GridItemLeft { get; private set; }

        [field: SerializeField]
        public GridItem GridItemRight { get; private set; }
    }
}
