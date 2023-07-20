using UnityEngine;
using TMPro;

namespace Tower_Bloxx
{
    public sealed class MaxRecord : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private int _recordValue;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void GetValue(int value)
        {
            _recordValue = value;
            _text.text = $"Max Value: {_recordValue}";
        }
    }
}

