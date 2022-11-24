using System.Collections;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _forceRebound = 300;
    
    private Vector3 _currenScale;

    private void Awake()
    {
        _currenScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var ball = col.gameObject.GetComponent<Ball>();
        if (ball == null)
            return;
        
        ball.Rebound(_forceRebound);
        StartCoroutine(Deformation());
    }

    private IEnumerator Deformation()
    {
        transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = _currenScale;
    }
}
