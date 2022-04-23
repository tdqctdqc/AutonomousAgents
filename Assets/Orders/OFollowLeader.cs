using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OFollowLeader : Order
{
    public OFollowLeader(GameObject go, Vector3 offset, Target leaderTarget)
    {
        target = new Target(go, offset, leaderTarget);
        bProfile = new BehaviorProfile(0, 0, 0, 1, 0, 0, 3, 0, 0, 0, 0, 0, 0);
    }

    public override BehaviorProfile bProfile { get; }
    public override Target target { get; set; }

    public override OrderCompleteCondition completeCondition { get; }

}
