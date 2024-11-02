using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Channel", menuName = "Channels/Ball")]
public class BallChannel : ScriptableObject
{
    public Action NoMoreBalls;
    public Action NotEnoughPointsToWin;
    public Action NotEnoughPointsToLose;

    public void NoMoreBallsLeft()
    {
        NoMoreBalls?.Invoke();
    }

    public void NotEnoughPointsLeftToWin()
    {
        NotEnoughPointsToWin?.Invoke();
    }

    public void NotEnoughPointsLeftToLose()
    {
        NotEnoughPointsToLose?.Invoke();
    }
}