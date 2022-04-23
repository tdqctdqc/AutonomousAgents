using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSeek : Behavior
{
    Vector3 target => mono.TargetPos;
    Rigidbody2D rb => mono.RB;
    Steerer steerer;

    BehaviorMono mono;
    bool set = false;
    public override string behaviorName => this.name;
    // Start is called before the first frame update
    void Start()
    {
        mono = GetComponentInParent<BehaviorMono>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (set == false)
        {
            steerer = mono.Steerer;

            set = true;
        }
    }

    public override void Behave(float weight)
    {
        if (target != null)
        {
            if ((mono.sub.groupController.FormationAnchor - mono.sub.groupController.order.target.TargetCoordinates).magnitude > 1f)
            //if ((transform.position - target).magnitude > .1f)
            {
                DoSeek(mono.calc, transform.position, target, rb, steerer, weight);
            }
        }
    }
    public static void DoSeek (BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Steerer steerer, float speed)
    {
        AgentUtility.SeekAvoidInGroup(handler, callerPos, targetPos, callerRB, steerer, speed, 1);
    }


    
}
