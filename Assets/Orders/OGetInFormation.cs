using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OGetInFormation : Order
{
    public OGetInFormation(OrderCompleteCondition o = null)
    {
        bProfile = new BehaviorProfile(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
        if (o != null)
        {
            completeCondition = o;
        }
        else
        {
            completeCondition = new OCInFormation();
        }
        
    }
    public override BehaviorProfile bProfile { get; }

    public override Target target { get; set; }
    public override OrderCompleteCondition completeCondition { get; }
}
