using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCWithinDistanceOfTarget : OrderCompleteCondition
{
    float arriveDist;

    public OCWithinDistanceOfTarget(float arriveDist)
    {
        this.arriveDist = arriveDist;
    }

    public override bool CheckCompleted(GroupController group)
    {
        if ( Vector3.Distance(group.FormationAnchor, group.order.target.TargetCoordinates) < arriveDist )
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}
