using UnityEngine;

namespace Tower_Bloxx
{
    public class GamePanel : BasePanel
    {
        [field: SerializeField]
        public TapPanel TapPanel { get; private set; }

        [field: SerializeField]
        public Counter Counter { get; private set; }
    }
}
