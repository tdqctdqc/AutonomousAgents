using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BStayInFormation : Behavior
{
    Rigidbody2D rb => mono.RB;
    BehaviorMono mono;
    public static float tolerance = .2f; 
    public override string behaviorName => this.name;
    public override void Behave(float weight)
    {
        Vector3 anchor = mono.sub.Squad.SquadAnchor; 
        Vector3 desiredPos = anchor + mono.sub.formationPositionAdjusted;
        float dist = (transform.position - desiredPos).magnitude;
        if ( dist > tolerance) 
        {
        
            Vector3 force = (desiredPos - transform.position).normalized;
            float speedRatio = Mathf.Min(.75f, dist);
            WeightedDirection wd = new WeightedDirection(force, weight, speedRatio, false);
            mono.sub.InFormation = false;
            mono.calc.GiveWeightedDirection(wd);
        }
        else
        {
            mono.sub.InFormation = true; 
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        mono = GetComponentInParent<BehaviorMono>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
