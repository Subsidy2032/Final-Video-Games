using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallWallCollisionChannel", menuName = "Channels/BallWallCollision", order = 1)]

public class BallHoleCollisionChannel : ScriptableObject
{
    public event Action<GameObject, string, string> CollisionDetected;

    public void InvokeCollisionDetected(GameObject ball, string tag, string color)
    {
        CollisionDetected?.Invoke(ball, tag, color);
    }
}