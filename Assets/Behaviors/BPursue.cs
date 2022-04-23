using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPursue : Behavior
{
    Vector3 target => mono.TargetPos;
    Crosshair crosshair; 
    Rigidbody2D rb => mono.RB;
    Rigidbody2D targetRB => mono.TargetRB;
    Steerer steerer;
    public float acceleration = 1f;
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
            crosshair = mono.Crosshair;
            steerer = mono.Steerer;
        }

        set = true;
    }

    public override void Behave(float weight)
    {
        if (target != null && targetRB != null)
        {
            DoPursue(mono.calc, transform.position, target, rb, targetRB, weight, steerer, crosshair);
        }
    }


    public static void DoPursue (BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Rigidbody2D targetRB, float speed, Steerer steerer, Crosshair crosshair)
    {
        AgentUtility.PursueEvade(handler, callerPos, targetPos, callerRB, targetRB, speed, steerer, crosshair, 1);
    }

}
