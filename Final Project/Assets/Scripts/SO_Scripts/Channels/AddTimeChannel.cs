using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Add Time Channel", menuName = "Channels/AddTime")]
public class AddTimeChannel : ScriptableObject
{
    public Action<int> AddTime;

    public void BoosterCollected(int secondsToAdd)
    {
        AddTime?.Invoke(secondsToAdd);
    }
}
