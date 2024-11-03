using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackBalls : MonoBehaviour
{
    [SerializeField] private GameObject ballsParent;
    [SerializeField] private PlayerScoreChannel pScoreChannel;
    [SerializeField] private LevelRequirementsSO lvlReq;

    private List<GameObject> balls = new();
    private BallHoleCollisionChannel ballHoleCollisionChannel;
    private BallChannel ballChannel;
    
    int points = 0;
    

void Start()
    {
        Beacon beacon = Beacon.GetInstance();

        ballHoleCollisionChannel = beacon.ballHoleCollisionChannel;
        ballHoleCollisionChannel.CollisionDetected += RemoveBallFromList;
        ballChannel = beacon.ballChannel;
        pScoreChannel = beacon.playerScoreChannel;
        pScoreChannel.ScoreUpdate += UpdatePoints;

        foreach (var ball in ballsParent.GetComponentsInChildren<Transform>())
        {
            if (ball != ballsParent.transform)
            {
                balls.Add(ball.gameObject);
            }
        }
    }

    private void UpdatePoints(int points)
    {
        this.points = points;
    }
    private void RemoveBallFromList(GameObject ball, string tag, string color)
    {
        balls.Remove(ball);

        if (balls.Count == 0)
        {
            ballChannel.NoMoreBallsLeft();
        }
    }

    private void Update()
    {
        if (balls.Count != 0)
        {
            int reqPoints = lvlReq.requiredPoints[SceneManager.GetActiveScene().name];
            int maxPointsToGet = balls.Count * (balls[0].GetComponent<BallScript>().sO_Ball.addPoints);
            int maxPointsToLose = balls.Count * (balls[0].GetComponent<BallScript>().sO_Ball.deductPoints);

            if (maxPointsToGet + points < reqPoints)
            {
                ballChannel.NotEnoughPointsToWin();
            }

            if (maxPointsToLose + points > reqPoints)
            {
                ballChannel.NotEnoughPointsToLose();
                Time.timeScale = 0;
            }
        }
    }
}
