using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorCalculator
{
    public BehaviorMono mono;
    Steerer steerer;
    Crosshair crosshair; 

    Vector3 desiredVelocity;
    Vector3 cachedCrossHairPos;

    List<WeightedDirection> weightedDirections; //in localspace

    public BehaviorCalculator (BehaviorMono mono, Steerer steerer, Crosshair crosshair)
    {
        this.steerer = steerer;
        this.crosshair = crosshair;
        this.mono = mono;
        desiredVelocity = Vector3.zero;
        cachedCrossHairPos = mono.transform.position;
    }

    public void DoBehaviors ()
    {
        weightedDirections = new List<WeightedDirection>();
        desiredVelocity = Vector3.zero;
        float speedBid = 0; 

        foreach (BehaviorWeight bw in mono.Manager.weights)
        {
            float tempWeight = bw.weight;
            if (tempWeight > 0)
            {
                bw.behavior.Behave(tempWeight);
            }
        }

        foreach (WeightedDirection wd in weightedDirections)
        {
            desiredVelocity += wd.direction.normalized * wd.weight;
            if (wd.speedRatio > speedBid)
            {
                speedBid = wd.speedRatio;
            }
        }

        Vector3 forceToAdd = desiredVelocity.normalized * mono.speed * speedBid  - (Vector3)mono.RB.velocity;

        steerer.AddForce(forceToAdd);

        Vector3 crosshairLerp = Vector3.Lerp(cachedCrossHairPos, mono.transform.position + desiredVelocity + (Vector3)mono.RB.velocity, .1f);
        crosshair.SetPosition(crosshairLerp);
        cachedCrossHairPos = crosshairLerp;
        desiredVelocity = Vector3.zero;
    }


    public void GiveWeightedDirection(WeightedDirection wd)
    {
        weightedDirections.Add(wd);
    }
}
