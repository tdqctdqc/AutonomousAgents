using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Order
{
    public abstract Target target { get; set; }
    public abstract BehaviorProfile bProfile { get; }
    public abstract OrderCompleteCondition completeCondition { get; }

}
