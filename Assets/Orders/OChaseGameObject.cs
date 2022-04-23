using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OChaseGameObject : Order
{
    public OChaseGameObject(GameObject go, Vector3 offset)
    {
        target = new Target(go, offset);
        bProfile = new BehaviorProfile(0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 0, 2);
        completeCondition = new OCWithinDistanceOfTarget(1f);
    }

    public override BehaviorProfile bProfile { get; }
    public override Target target { get; set; }
    public override OrderCompleteCondition completeCondition { get; }
}
