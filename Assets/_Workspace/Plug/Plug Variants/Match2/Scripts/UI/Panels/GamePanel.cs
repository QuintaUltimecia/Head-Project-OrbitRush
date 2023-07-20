using System;
using UnityEngine;

namespace Match2
{
    public class GamePanel : BasePanel
    {
        [field: SerializeField]
        public Match2 Match2 { get; private set; }

        [field: SerializeField]
        public Points Points { get; private set; }
    }
}
