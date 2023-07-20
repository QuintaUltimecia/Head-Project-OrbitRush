using UnityEngine;
using TMPro;

namespace Slots
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Money : MonoBehaviour
    {
        private int _value;

        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateText()
        {
            _text.text = $"Money: {_value}";
        }

        public void GetMoney(int value)
        {
            _value += value;

            UpdateText();
        }

        public void RemoveMoney(int value)
        {
            _value -= value;

            UpdateText();
        }
    }
}

