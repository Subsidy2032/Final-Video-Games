using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Timer Channel", menuName = "Channels/Timer")]
public class TimerChannel : ScriptableObject
{
    public Action<float> TimeEnd;

    public void TimeEnded(float runningTime)
    {
        TimeEnd?.Invoke(runningTime);
    }
}
