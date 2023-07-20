using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public int Value { get; private set; }

    private TextMeshProUGUI _text;

    public void AddPoints(int value)
    {
        Value += value;
        UpdateText();
    }

    public void RemovePoints()
    {
        Value = 0; 
        UpdateText();
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private  void UpdateText()
    {
        _text.text = $"Moves: {Value}";
    }
}
