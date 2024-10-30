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
    BallChannel ballChannel;
    PlayerScoreChannel playerScoreChannel;
    [SerializeField] private LevelRequirementsSO levelRequirements;
    private Dictionary<string, int> requiredPoints;

    private void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        timerChannel = beacon.timerChannel;
        ballChannel = beacon.ballChannel;
        playerScoreChannel = beacon.playerScoreChannel;

        timerChannel.TimeEnd += HandleLevelEnd;
        ballChannel.NoMoreBalls += HandleLevelEnd;
        playerScoreChannel.ScoreUpdate += CheckIfEnoughPoints;

        requiredPoints = levelRequirements.requiredPoints;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void CheckIfEnoughPoints(int points)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (points >= requiredPoints[currentSceneName])
        {
            canTransition = true;
            Time.timeScale = 0;
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        canTransition = false;
    }

    private void HandleLevelEnd(float runningTime)
    {
        canTransition = true;
    }

    private void HandleLevelEnd()
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
