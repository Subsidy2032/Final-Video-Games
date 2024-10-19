using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTransition : TransitionBase
{
    [SerializeField] private bool canTransition = false;
    [SerializeField] private bool transitionTriggered = false;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sourceState.isCurrentState)
        {
            canTransition = true;
            transitionTriggered = false;
        }
    }

    public override bool ShouldTransition()
    {
        if (!base.ShouldTransition())
            return false;

        if (canTransition && !transitionTriggered)
        {
            canTransition = false;
            transitionTriggered = true;
            return true;
        }

        return false;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}