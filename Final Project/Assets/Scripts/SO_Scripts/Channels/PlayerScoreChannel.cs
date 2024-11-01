using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Score Channel", menuName = "Channels/Player Score")]
public class PlayerScoreChannel : ScriptableObject
{
    public Action<int> ScoreUpdate;

    public void ScoreUpdated(int points)
    {
        ScoreUpdate?.Invoke(points);
    }
}
