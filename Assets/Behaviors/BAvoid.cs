using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAvoid : Behavior
{
    Vector3 target => mono.TargetPos;
    Rigidbody2D rb;
    Steerer steerer;
    public float maxSpeed = 1f;

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
            rb = mono.RB;
            steerer = mono.Steerer;
            set = true;
        }
    }
    public override void Behave(float weight)
    {
        if (target != null)
        {
            DoAvoid(mono.calc, transform.position, target, rb, steerer, weight);
        }
        
    }

    public static void DoAvoid (BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Steerer steerer, float speed)
    {
        AgentUtility.SeekAvoidInGroup(handler, callerPos, targetPos, callerRB, steerer, speed, -1);
    }
}
