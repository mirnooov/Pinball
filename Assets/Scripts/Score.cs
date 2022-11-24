using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    public int Amount { get; private set; }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore(int amount)
    {
        Amount += amount;
        _text.text = Amount.ToString();
    }
    
    public void RemoveScore()
    {
        Amount = 0;
        _text.text = Amount.ToString();
    }
}