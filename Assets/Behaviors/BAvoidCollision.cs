using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAvoidCollision : Behavior
{
    Rigidbody2D rb => mono.RB;
    Steerer steerer;
    Collider2D col; 
    public float avoidDist = .5f;
    public float avoidWidth= .1f;
    public float maxSpeed = 1f;
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

            col = mono.Col;
            steerer = mono.Steerer;
            set = true;
        }
    }

    public override void Behave(float weight)
    {
        DoAvoidCollision(mono.calc, transform.position, rb, steerer, avoidWidth, avoidDist, weight);
    }

    public static void DoAvoidCollision (BehaviorCalculator handler, Vector3 callerPos, Rigidbody2D callerRB, Steerer steerer, float avoidWidth, float avoidDist, float speed)
    {
        List<Collider2D> cols = AgentUtility.GetObstacleCollidersInBox(callerPos, callerRB, avoidWidth, avoidDist);
        if (cols.Count > 0)
        {
            Collider2D col = AgentUtility.FindClosestCollider(callerPos, cols);
            AgentUtility.SteerAwayFromCollider(handler, callerPos, callerRB, col, steerer, avoidDist, speed);
        }
    }


    
}
