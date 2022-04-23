using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    public abstract void Behave(float weight);

    public abstract string behaviorName { get;}

}
