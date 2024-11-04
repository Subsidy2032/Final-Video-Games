using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreenTransition : TransitionBase
{
    bool canTransition = false;
    TimerChannel timerChannel;
    BallChannel ballChannel;
    [SerializeField] private LevelRequirementsSO levelRequirements;

    private void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        timerChannel = beacon.timerChannel;
        ballChannel = beacon.ballChannel;

        timerChannel.TimeEnd += HandleLevelEnd;
        ballChannel.NoMoreBalls += HandleLevelEnd;
        ballChannel.NotEnoughPointsToWin += HandleLevelEnd;
        ballChannel.NotEnoughPointsToLose += HandleLevelEnd;

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
        timerChannel.TimeEnd -= HandleLevelEnd;
        ballChannel.NoMoreBalls -= HandleLevelEnd;
        ballChannel.NotEnoughPointsToWin -= HandleLevelEnd;
        ballChannel.NotEnoughPointsToLose -= HandleLevelEnd;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
