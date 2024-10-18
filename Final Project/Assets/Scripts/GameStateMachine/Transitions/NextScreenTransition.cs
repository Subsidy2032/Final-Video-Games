using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NextScreenTransition : TransitionBase
{
    [SerializeField] float runningTime;

    void Update()
    {
        if (runningTime > 0)
        {
            runningTime -= Time.deltaTime;
        }

        if (runningTime <= 0)
        {
            
        }
    }

    public void IncTime()
    {
        runningTime += 5;
    }
}
