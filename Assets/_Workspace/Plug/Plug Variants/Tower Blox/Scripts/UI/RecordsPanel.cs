using UnityEngine;

namespace Tower_Bloxx
{
    public sealed class RecordsPanel : BasePanel
    {
        [field: SerializeField]
        public MaxRecord MaxRecord { get; private set; }
    }
}
