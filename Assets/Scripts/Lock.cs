using TMPro;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] private Animator _leftGrate;
    [SerializeField] private Animator _rightGrate;

    [SerializeField] private TextMeshProUGUI _lockScores;
    [SerializeField] private int _unlockScoresCounter = 100;
    
    private static readonly int Unlock = Animator.StringToHash("Unlock");

    private void Awake()
    {
        _lockScores.text = _unlockScoresCounter.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var ball = col.gameObject.GetComponent<Ball>();
        if (ball == null)
            return;

        _unlockScoresCounter -= ball.ScoreOnBall.Amount;
        ball.ScoreOnBall.RemoveScore();
        
        _lockScores.text = _unlockScoresCounter.ToString();

        if (_unlockScoresCounter <= 0)
        {
            ball.EnabledGhostBall();
            
            _leftGrate.SetTrigger(Unlock);
            _rightGrate.SetTrigger(Unlock);
            
            Destroy(gameObject);
        }
    }
}
