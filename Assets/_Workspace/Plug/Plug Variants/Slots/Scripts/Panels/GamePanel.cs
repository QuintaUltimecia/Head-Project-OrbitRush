using UnityEngine;

namespace Slots
{
    public class GamePanel : BasePanel
    {
        [field: SerializeField]
        public Money Money { get; private set; }
    }
}
