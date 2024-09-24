using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallWallCollisionChannel", menuName = "Channels/BallWallCollision", order = 1)]

public class BallHoleCollisionChannel : ScriptableObject
{
    public event Action<GameObject, string> CollisionDetected;

    public void InvokeCollisionDetected(GameObject ball, string tag)
    {
        if (SharedFunctions.GetInstance().IsOutOfBounds(ball, tag))
            CollisionDetected?.Invoke(ball, tag);
    }
}