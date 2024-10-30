using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball Channel", menuName = "Channels/Ball")]
public class BallChannel : ScriptableObject
{
    public Action NoMoreBalls;

    public void NoMoreBallsLeft()
    {
        NoMoreBalls?.Invoke();
    }
}