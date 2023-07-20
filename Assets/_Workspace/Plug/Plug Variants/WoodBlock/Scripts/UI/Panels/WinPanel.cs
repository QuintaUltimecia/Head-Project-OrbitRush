using UnityEngine;

namespace WoodBlock
{
    public class WinPanel : BasePanel
    {
        [field: SerializeField]
        public NextButton NextPanel { get; private set; }
    }
}
