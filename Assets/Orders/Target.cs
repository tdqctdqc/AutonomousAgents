using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target 
{
    //add way to follow gameobject at an offset 
    public bool hasObjectAsTarget => (targetObject != null);
    public Target(GameObject tar, Vector3 offset, Target leaderTarget)
    {
        targetObject = tar;
        this.offset = offset;
        this.leaderTarget = leaderTarget;
    }
    public Target(GameObject tar, Vector3 offset)
    {
        targetObject = tar;
        this.offset = offset; 
    }
    public Target(Vector3 pos)
    {
        targetPosition = pos; 
    }


    GameObject targetObject;
    public Rigidbody2D targetRB
        {get {
        if (targetObject != null)
        { return targetObject.GetComponent<Rigidbody2D>();}
        else
        {return null;}}
        }
    public Vector3 TargetCoordinates
    {
        get
        {
            if (targetObject != null)
            { return targetObject.transform.position; }
            else
            { return targetPosition; }
        }
    }

    Vector3 targetPosition;
    Vector3 offset;
    Target leaderTarget; 
    public Vector3 GetTarget
    {
        get
        {
            if (targetObject != null)
            {
                if(leaderTarget != null)
                {
                    return targetObject.transform.position + Quaternion.FromToRotation(Vector3.up, leaderTarget.TargetCoordinates - targetObject.transform.position) * offset; 
                    //targetObject.transform.rotation * offset;
                }
                else
                {
                    return targetObject.transform.position + Quaternion.FromToRotation(Vector3.up, targetRB.velocity) * offset;
                    //targetObject.transform.rotation * offset;
                }
            }
            else
            {
                return targetPosition;
            }
        }
    }
}
