using UnityEngine;

namespace Plinko
{
    public class GamePanel : BasePanel
    {
        [field: SerializeField]
        public Money Money { get; private set; }
    }
}
