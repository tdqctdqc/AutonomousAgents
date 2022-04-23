using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGoToLocation : Order
{
    public OGoToLocation(Vector3 loc)
    {
        target = new Target(loc);
        bProfile = new BehaviorProfile(0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 0, 2);
        completeCondition = new OCWithinDistanceOfTarget(1f);
    }
    public override BehaviorProfile bProfile { get; }
    public override Target target { get; set ; }
    public override OrderCompleteCondition completeCondition { get; }
}
