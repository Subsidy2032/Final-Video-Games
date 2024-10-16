using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UpdateScore : MonoBehaviour
{
    private BallHoleCollisionChannel ballHoleCollisionChannel;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        ballHoleCollisionChannel = Beacon.GetInstance().ballHoleCollisionChannel;
        ballHoleCollisionChannel.CollisionDetected += AddToScore;
    }

    void AddToScore(GameObject ball, string tag, string color)
    {
        BallScript ballScript = ball.GetComponent<BallScript>();
        SO_Ball sO_Ball = ballScript.sO_Ball;

        // Removing points if it's a red hole
        if (color == "green" ) 
        {
            score += sO_Ball.addPoints;
        }

        if (color == "red")
        {
            score += sO_Ball.removePoints;
        }

        scoreText.text = "Your Score: " + score;
    }
}
