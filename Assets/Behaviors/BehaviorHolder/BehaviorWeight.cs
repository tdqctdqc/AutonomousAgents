using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBehavior", menuName = "ScriptableObjects/Behavior")]
public class BehaviorWeight : ScriptableObject
{
    public float weight;
    public Behavior behavior;
}
