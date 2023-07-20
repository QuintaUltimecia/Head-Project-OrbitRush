using UnityEngine;
using TMPro;

namespace Plinko
{
    public class Money : MonoBehaviour
    {
        public float Value { get; private set; } = 100;

        private TextMeshProUGUI _text;

        private float _lastBet;

        public void GetMoney(int bet, float multiplier)
        {
            Value += bet * multiplier;

            UpdateText();
        }

        public void RemoveMoney(int bet)
        {
            _lastBet = bet;

            Value -= _lastBet;

            UpdateText();
        }

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateText()
        {
            _text.text = $"Money: {Value}";
        }
    }
}
