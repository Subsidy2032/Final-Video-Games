using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UpdateScore : MonoBehaviour
{
    private BallHoleCollisionChannel ballHoleCollisionChannel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] PlayerScoreChannel playerScoreChannel;
    private int score = 0;

    void Start()
    {
        playerScoreChannel = Beacon.GetInstance().playerScoreChannel;

        ballHoleCollisionChannel = Beacon.GetInstance().ballHoleCollisionChannel;
        ballHoleCollisionChannel.CollisionDetected += AddToScore;
    }

    void AddToScore(GameObject ball, string tag, string color)
    {
        BallScript ballScript = ball.GetComponent<BallScript>();
        SO_Ball sO_Ball = ballScript.sO_Ball;

        if (color == "green" ) 
        {
            score += sO_Ball.addPoints;
        }

        if (color == "red")
        {
            score += sO_Ball.removePoints;
        }

        playerScoreChannel.ScoreUpdated(score);

        scoreText.text = "Your Score: " + score;
    }
}
