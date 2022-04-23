using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAvoidCollisionNormal : Behavior
{
    Rigidbody2D rb => mono.RB;
    Steerer steerer;
    Collider2D col;
    public float avoidDist = .5f;
    public float avoidWidth = .1f;
    public float maxSpeed = 1f;
    bool set = false;
    BehaviorMono mono;
    float rayLength = 1f;
    float sideRayAngle = 20f;
    float sideRayRatio = .02f;
    LayerMask mask; 

    List<RaycastHit2D> hits;
    public override string behaviorName => this.name;

    // Start is called before the first frame update
    void Start()
    {
        mono = GetComponentInParent<BehaviorMono>();
        hits = new List<RaycastHit2D>();
        mask = LayerMask.GetMask("Obstacle");
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
        
        Vector3 dodge = DetectCollisionNormalDodge(mono.transform.position, rb, hits, rayLength, sideRayAngle, sideRayRatio, mask);
        if (dodge != Vector3.zero)
        {
            WeightedDirection wd = new WeightedDirection(dodge.normalized, weight, .5f, false);
            mono.calc.GiveWeightedDirection(wd);
        }
        
    }




    public static RaycastHit2D CastRayToObstacle (Vector3 callerPos, Vector3 ray, float length, LayerMask mask)
    {
        RaycastHit2D hit = Physics2D.Raycast(callerPos, ray, length);
        Obstacle ob = hit.collider.gameObject.GetComponent<Obstacle>();
       
        return hit;
    }

    public static Vector3 DetectCollisionNormalDodge (Vector3 callerPos, Rigidbody2D callerRB, List<RaycastHit2D> hits, float rayLength, float sideRayAngle, float sideRayRatio, LayerMask mask)
    {
        hits.Clear();
        Quaternion rot1 = Quaternion.Euler(0, 0, sideRayAngle);
        Quaternion rot2 = Quaternion.Euler(0, 0, -sideRayAngle);
        hits.Add(CastRayToObstacle(callerPos, callerRB.velocity, rayLength, mask));
        hits.Add(CastRayToObstacle(callerPos, rot1 * callerRB.velocity, rayLength * sideRayRatio, mask));
        hits.Add(CastRayToObstacle(callerPos, rot2 * callerRB.velocity, rayLength * sideRayRatio, mask));

        Vector3 dodge = Vector3.zero;
        Vector3 vel = (Vector3)callerRB.velocity; 
        for (int i = 0; i < hits.Count; i++)
        {
            if (hits[i].collider != null )
            {

                Vector3 normal = hits[i].normal;
                float angle = Vector3.SignedAngle(callerRB.velocity, normal, Vector3.forward);
                int leftRight = 1;
                if (angle < 0)
                {
                    leftRight = -1;
                }
                //Vector3 perpProj = normal - (vel) * (Vector3.Dot(normal, vel) / (vel.magnitude * vel.magnitude) );

                dodge += Quaternion.Euler(0, 0, leftRight * -90f) * callerRB.velocity; 
            }
        }
        return dodge; 
    }

}
