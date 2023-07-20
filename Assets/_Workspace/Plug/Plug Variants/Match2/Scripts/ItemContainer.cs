using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Match2
{
    public class ItemContainer : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField]
        public Item Item { get; private set; }

        private Match2 _match2;

        public void Init(Match2 match2)
        {
            _match2 = match2;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_match2.CheckDuplicates() < 2 && Item.IsSelected == false)
            {
                _match2.AddDuplicateItems(this);
                Item.SetAlpha(false);
            }
        }
    }
}
