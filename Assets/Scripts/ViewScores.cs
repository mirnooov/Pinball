using System.Collections;
using TMPro;
using UnityEngine;

public class ViewScores : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 0.6f;
    [SerializeField] private float _speedup = 300;
    
    private TextMeshProUGUI _scoreText;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfter(_lifeTime));
    }

    private void Update()
    {
        _rectTransform.anchoredPosition = Vector2.MoveTowards(
            _rectTransform.anchoredPosition,
            _rectTransform.anchoredPosition + Vector2.up,
            _speedup * Time.deltaTime);
    }

    public void Init(Vector2 position)
    {
        _rectTransform.anchoredPosition = position;
    }

    public void SetScore(int value)
    {
        _scoreText.text = "+" + value;
    }

    private IEnumerator DestroyAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}