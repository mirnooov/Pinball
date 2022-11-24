using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private GhostBall _ghostBall;
    [SerializeField] private float _force = 600;
    [SerializeField] private Score _scoreOnBall;
    
    private Rigidbody2D _rigidbody2D;

    public Score ScoreOnBall => _scoreOnBall;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        var flipper = col.gameObject.GetComponent<Flipper>();
        
        if (flipper && flipper.IsPressed)
            Rebound();
    }
    public void Rebound(float force = 0)
    {
        _rigidbody2D.AddForce(force == 0
            ? Vector2.up * _force
            : Vector2.up * force);
    }

    public void EnabledGhostBall()
    {
        _ghostBall.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}