using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class TrackBalls : MonoBehaviour
{
    [SerializeField] private GameObject ballsParent;
    private List<GameObject> balls = new();

    private BallHoleCollisionChannel ballHoleCollisionChannel;
    private BallChannel ballChannel;

    void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        ballHoleCollisionChannel = beacon.ballHoleCollisionChannel;
        ballHoleCollisionChannel.CollisionDetected += RemoveBallFromList;

        ballChannel = beacon.ballChannel;

        foreach (var ball in ballsParent.GetComponentsInChildren<Transform>())
        {
            if (ball != ballsParent.transform)
            {
                balls.Add(ball.gameObject);
            }
        }
    }

    private void RemoveBallFromList(GameObject ball, string tag, string color)
    {
        balls.Remove(ball);

        if(balls.Count == 0)
        {
            ballChannel.NoMoreBallsLeft();
        }
    }

    void Update()
    {
        
    }
}
