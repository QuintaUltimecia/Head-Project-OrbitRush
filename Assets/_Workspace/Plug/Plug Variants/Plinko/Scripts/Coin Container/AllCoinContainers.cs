using UnityEngine;

namespace Plinko
{
    public class AllCoinContainers : MonoBehaviour
    {
        [field: SerializeField]
        public GreenContainer GreenContainer { get; private set; }

        [field: SerializeField]
        public OrangeContainer OrangeContainer { get; private set; }

        [field: SerializeField]
        public RedContainer RedContainer { get; private set; }
    }
}
