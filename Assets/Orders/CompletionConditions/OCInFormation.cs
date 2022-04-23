using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCInFormation : OrderCompleteCondition
{

    public override bool CheckCompleted(GroupController group)
    {
        bool inFormation = true; 
        if (group.subordinates[0] == null)
        {
            return false; 
        }
        while (inFormation == true)
        {
            foreach (var sub in group.subordinates)
            {
                if (sub.InFormation == false)
                {
                    inFormation = false;
                }
            }
            break;
        }
        return inFormation;
    }
}
