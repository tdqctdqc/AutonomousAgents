using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class WeightedDirection
{
    public Vector3 direction { get; private set; } //in localspace
    public float weight { get; private set; }
    public bool isOverride { get; private set; }
    public float speedRatio;

    public WeightedDirection (Vector3 direction, float weight, float speedRatio, bool isOverride)
    {
        this.direction = direction;
        this.weight = weight;
        this.isOverride = isOverride;
        this.speedRatio = speedRatio;
    }
}
