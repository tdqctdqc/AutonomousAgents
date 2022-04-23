using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCDestroyedObject : OrderCompleteCondition
{
    GameObject target;

    public OCDestroyedObject(GameObject target)
    {
        this.target = target;
    }

    public override bool CheckCompleted(GroupController group)
    {
        if (target == null || target.activeSelf == false)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }
}
