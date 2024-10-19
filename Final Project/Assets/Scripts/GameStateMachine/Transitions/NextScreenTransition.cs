using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreenTransition : TransitionBase
{
    bool canTransition = false;
    TimerChannel timerChannel;

    private void Start()
    {
        timerChannel = Beacon.GetInstance().timerChannel;
        timerChannel.TimeEnd += HandleLevelEnd;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        canTransition = false;
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
