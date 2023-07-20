using UnityEngine;

namespace Tower_Bloxx
{
    public class HeadObject : MonoBehaviour
    {
        [field: SerializeField]
        public Holder Holder { get; private set; }

        [field: SerializeField]
        public Platform Platform { get; private set; }
    }
}
