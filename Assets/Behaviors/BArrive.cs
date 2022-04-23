using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BArrive : Behavior
{
    Vector3 target => mono.TargetPos;
    Rigidbody2D rb => mono.RB;
    Steerer steerer;
    public float slowingDistance = 1f;
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
            DoArrive(mono.calc, transform.position, target, rb, steerer, weight, slowingDistance);
        }
    }

    public static void DoArrive(BehaviorCalculator handler, Vector3 callerPos, Vector3 targetPos, Rigidbody2D callerRB, Steerer steerer, float speed, float slowingDist)
    {
        float clippedSpeed = AgentUtility.ScaleSpeedWithDistance(callerPos, targetPos, speed, slowingDist);
        BSeek.DoSeek(handler, callerPos, targetPos, callerRB, steerer, clippedSpeed);
    }

}
