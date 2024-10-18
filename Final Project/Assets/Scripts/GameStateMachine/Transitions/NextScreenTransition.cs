using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextScreenTransition : TransitionBase
{
    bool canTransition = false;
    TimerChannel timerChannel;

    private void Start()
    {
        timerChannel = Beacon.GetInstance().timerChannel;
        timerChannel.TimeEnd += HandleLevelEnd;
    }

    private void HandleLevelEnd(float runningTime)
    {
        canTransition = true;
    }

    public override bool ShouldTransition()
    {
        if (canTransition && base.ShouldTransition())
        {
            canTransition = false;
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        if (timerChannel != null)
        {
            timerChannel.TimeEnd -= HandleLevelEnd;
        }
    }
}
