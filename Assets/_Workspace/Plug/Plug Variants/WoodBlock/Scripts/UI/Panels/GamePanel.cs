using UnityEngine;

namespace WoodBlock
{
    public class GamePanel : BasePanel
    {
        [field: SerializeField]
        public WoodBlockContainer WoodBlockContainer { get; private set; }

        [field: SerializeField]
        public LevelManager LevelManager { get; private set; }
    }
}
