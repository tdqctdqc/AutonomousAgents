using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCTimer : OrderCompleteCondition
{
    float startTime;
    float timerLength; 
    public OCTimer (float timerLength, float startTime)
    {
        this.startTime = startTime;
        this.timerLength = timerLength; 
    }
    public override bool CheckCompleted(GroupController group)
    {
        if (Time.time > startTime + timerLength)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}
