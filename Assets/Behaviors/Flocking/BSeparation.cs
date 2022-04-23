using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSeparation : Behavior
{
    Rigidbody2D rb => mono.RB;
    BehaviorMono mono;
    float radius = 1f;
    List<Flocker> flockers;
    public override string behaviorName => this.name;
    public override void Behave(float weight)
    {

        flockers = AgentUtility.GetFlockersInRadius(transform.position, mono.Flocker, radius);
        if (flockers.Count > 0)
        {
            Vector3 avg = AgentUtility.GetAveragePositionOfFlockers(flockers);
            Vector3 force = (avg - transform.position).normalized;


            WeightedDirection wd = new WeightedDirection(-force, weight, .5f, false);

            mono.calc.GiveWeightedDirection(wd);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mono = GetComponentInParent<BehaviorMono>();
        
        flockers = new List<Flocker>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
