using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWander : Order
{
    public OWander(Vector3 loc)
    {
        target = new Target(loc);
        bProfile = new BehaviorProfile(0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0);
    }
    public OWander(Vector3 loc, OrderCompleteCondition cond)
    {
        target = new Target(loc);
        bProfile = new BehaviorProfile(0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0);
        completeCondition = cond; 
    }
    public OWander()
    {
        target = new Target(Vector3.zero);
        bProfile = new BehaviorProfile(0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0);
    }

    public override BehaviorProfile bProfile { get; }
    public override Target target { get ; set ; }

    public override OrderCompleteCondition completeCondition { get; }
}
