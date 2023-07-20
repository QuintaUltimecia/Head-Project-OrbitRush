using UnityEngine;
using TMPro;

namespace Tower_Bloxx
{
    public class Counter : MonoBehaviour
    {
        private int _count = 0;
        private TextMeshProUGUI _text;

        public System.Action<int> OnGetCount;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void GetCount(int value)
        {
            _count += value;

            _text.text = $"Count: {_count}";

            OnGetCount?.Invoke(_count);
        }

        public void ResetCount()
        {
            _count = 0;

            _text.text = $"Count: {_count}";
        }
    }
}

