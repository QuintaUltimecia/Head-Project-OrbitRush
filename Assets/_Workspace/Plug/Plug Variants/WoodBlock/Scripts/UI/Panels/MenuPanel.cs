using UnityEngine;

namespace WoodBlock
{
    public class MenuPanel : BasePanel
    {
        [field: SerializeField]
        public StartButton StartButton { get; private set; }
    }
}
