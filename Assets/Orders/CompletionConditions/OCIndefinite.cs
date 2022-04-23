using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCIndefinite : OrderCompleteCondition
{
    public override bool CheckCompleted(GroupController group)
    {
        return false; 
    }
}
