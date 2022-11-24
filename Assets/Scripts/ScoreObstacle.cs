using System.Collections;
using UnityEngine;

public class ScoreObstacle : MonoBehaviour
{
    [SerializeField] private ViewScores _viewScoresPrefab;
    [SerializeField] private Transform _canvasTransform;
    
    [SerializeField] private int _addScore = 5;
    
    public Vector2 _position;

    private void OnCollisionEnter2D(Collision2D col)
    {
        var ball = col.gameObject.GetComponent<Ball>();
        if (ball == null)
            return;

        StartCoroutine(WaitAddScore(ball.ScoreOnBall));
    }

    private IEnumerator WaitAddScore(Score ballScore)
    {
        AddScoreText(_addScore);
        ballScore.AddScore(_addScore);
        yield return new WaitForSeconds(0.3f);
    }
    
    private void AddScoreText(int amount)
    {
        var viewScores = Instantiate(_viewScoresPrefab, _canvasTransform, false);

        viewScores.Init(_position);
        viewScores.SetScore(amount);
    }
}