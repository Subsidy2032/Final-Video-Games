using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Channel", menuName = "Channels/Ball")]
public class BallChannel : ScriptableObject
{
    public Action NoMoreBalls;
    public Action NotEnoughPossiblePoints;

    public void NoMoreBallsLeft()
    {
        NoMoreBalls?.Invoke();
    }

    public void NotEnoughPossiblePointsLeft()
    {
        NotEnoughPossiblePoints?.Invoke();
    }

}