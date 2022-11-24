using System.Collections;
using UnityEngine;

public class GhostBall : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    
    private void OnEnable()
    {
        StartCoroutine(DestroyAfter(_lifeTime));
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
    }
    
    private IEnumerator DestroyAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
