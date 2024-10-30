using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallWallCollisionChannel", menuName = "Channels/BallWallCollision", order = 1)]

public class BallHoleCollisionChannel : ScriptableObject
{
    // Added another string to the event for the color
    public event Action<GameObject, string, string> CollisionDetected;

    public void InvokeCollisionDetected(GameObject ball, string tag, string color)
    {
        CollisionDetected?.Invoke(ball, tag, color);
    }
}