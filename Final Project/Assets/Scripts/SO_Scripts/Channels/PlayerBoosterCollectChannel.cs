using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallWallCollisionChannel", menuName = "Channels/PlayerBoosterCollect", order = 1)]

public class PlayerBoosterCollectChannel : ScriptableObject
{
    public event Action<GameObject> CollisionDetected;

    public void InvokeCollisionDetected(GameObject player)
    {
        CollisionDetected?.Invoke(player);
    }
}
