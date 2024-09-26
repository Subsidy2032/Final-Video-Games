using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallWallCollisionChannel", menuName = "Channels/BallWallCollision", order = 1)]

public class BallHoleCollisionChannel : ScriptableObject
{
    public event Action<GameObject, string> CollisionDetected;

    public void InvokeCollisionDetected(GameObject ball, string tag)
    {
        if (IsOutOfBounds(ball, tag))
            CollisionDetected?.Invoke(ball, tag);
    }

    public bool IsOutOfBounds(GameObject ball, string tag)
    {
        GameObject block = GameObject.FindWithTag(tag);
        float ballXPosition = ball.transform.position.x;
        float ballYPosition = ball.transform.position.y;

        float blockXPosition = block.transform.position.x;
        float blockYPosition = block.transform.position.y;

        if (tag == ObjectTagsEnum.LeftWall.ToString() && ballXPosition < blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.RightWall.ToString() && ballXPosition > blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.Ground.ToString() && ballYPosition < blockYPosition)
            return true;

        if (tag == ObjectTagsEnum.Ceiling.ToString() && ballYPosition > blockYPosition)
            return true;

        return false;
    }
}