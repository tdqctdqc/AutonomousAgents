using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAlignment : Behavior
{
    Rigidbody2D rb => mono.RB;
    BehaviorMono mono;
    float radius = 3f;
    List<Flocker> flockers;

    public override string behaviorName => "Alignment";

    public override void Behave(float weight)
    {
        flockers = AgentUtility.GetFlockersInRadius(transform.position, mono.Flocker, radius);
        if (flockers.Count > 0)
        {
            Vector3 avg = Vector3.zero;
            for (int i = 0; i < flockers.Count; i++)
            {
                avg += (Vector3)flockers[i].rb.velocity;
            }
            avg = 1f / (flockers.Count) * (avg);
            Vector3 force = transform.position + (avg - (Vector3)rb.velocity).normalized;
            WeightedDirection wd = new WeightedDirection(force, weight, .5f, false);

            mono.calc.GiveWeightedDirection(wd);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flockers = new List<Flocker>();
        mono = GetComponentInParent<BehaviorMono>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
