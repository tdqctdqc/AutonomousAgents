using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCWaitForSignal : OrderCompleteCondition
{
    bool signalled = false; 
    public void GetSignal()
    {
        signalled = true; 
    }
    public override bool CheckCompleted(GroupController group)
    {
        return signalled; 
    }
}
