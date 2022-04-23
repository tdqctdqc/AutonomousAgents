using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringArrow : MonoBehaviour
{
    BehaviorMono mono;
    LineRenderer lr;
    public Material mat;
    float displayLength = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        mono = gameObject.GetComponentInParent<BehaviorMono>();
        lr = gameObject.GetComponent<LineRenderer>();
        lr.material = mat; 
        lr.positionCount = 2;
        lr.startWidth = .02f;
        lr.endWidth = .02f;
        lr.startColor = Color.blue;
        lr.endColor = Color.blue; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void SetSteeringArrow (Vector3 dest)
    {
        float lengthNormalized = (dest - transform.position).magnitude / mono.speed; 
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + (dest - transform.position).normalized * lengthNormalized * displayLength);
    }
}
