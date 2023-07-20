using UnityEngine;
using UnityEngine.EventSystems;

namespace Tower_Bloxx
{
    public class TapPanel : MonoBehaviour, IPointerDownHandler
    {
        public System.Action OnTap;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnTap?.Invoke();
        }
    }
}
