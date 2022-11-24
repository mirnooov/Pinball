using System.Collections;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderer;
    [SerializeField] private float _force = 200;

    private Color _color;
    private bool _canAcceleration = true;

    private void Awake()
    {
        _color = _spriteRenderer[0].color;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var ball = collider2D.gameObject.GetComponent<Ball>();
        
        if (ball == null) 
            return;

        foreach (var sprite in _spriteRenderer)
            StartCoroutine(ChangeColor(sprite));

        if (_canAcceleration) 
            ball.Rebound(_force);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(CanAcceleration(1f));
    }
    
    private IEnumerator ChangeColor(SpriteRenderer changeColor)
    {
        changeColor.color = new Color(203, 217, 185, 1);
        yield return new WaitForSeconds(0.2f);
        changeColor.color = _color;
    }

    private IEnumerator CanAcceleration(float timeInSec)
    {
        _canAcceleration = false;
        yield return new WaitForSeconds(timeInSec);
        _canAcceleration = true;
    }
}