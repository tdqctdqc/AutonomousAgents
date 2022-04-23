using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPursueArrive : Behavior
{
    Vector3 target => mono.TargetPos;
    Crosshair crosshair;
    Rigidbody2D rb => mono.RB;
    Rigidbody2D targetRB => mono.TargetRB;
    Steerer steerer;
    public float acceleration = 1f;

    public float slowingDistance = 3f;
    bool set = false; 
    BehaviorMono mono;
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
            set = true; 
        }
    }
    public override void Behave(float weight)
    {
        if (target != null && targetRB != null)
        {
            DoPursueArrive(mono.calc, transform.position, target, rb, targetRB, steerer, crosshair, weight, slowingDistance);
        }
    }

    public static void DoPursueArrive (BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Rigidbody2D targetRB, Steerer steerer, Crosshair crosshair, float speed, float slowingDist)
    {
        Vector3 tar = AgentUtility.FindTargetFuturePos(callerRB, targetRB, callerPos, targetPos);
        float clippedSpeed = AgentUtility.ScaleSpeedWithDistance(callerPos, tar, speed, slowingDist);
        BPursue.DoPursue(handler, callerPos, tar, callerRB, targetRB, clippedSpeed, steerer, crosshair); 
    }
}
