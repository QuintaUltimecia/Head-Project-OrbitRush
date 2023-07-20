using UnityEngine;

namespace Plinko
{
    public class Grid : BasePlugObject
    {
        [field: SerializeField]
        public GridItem HeadItem { get; private set; }
    }
}
