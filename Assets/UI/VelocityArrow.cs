using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityArrow : MonoBehaviour
{
    BehaviorMono mono;
    public Material mat;
    LineRenderer lr;
    Rigidbody2D rb;
    float displayLength = 2f; 
    // Start is called before the first frame update
    void Start()
    {
        mono = gameObject.GetComponentInParent<BehaviorMono>();
        lr = gameObject.GetComponent<LineRenderer>();
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        lr.material = mat;
        lr.positionCount = 2;
        lr.startWidth = .02f;
        lr.endWidth = .02f;
        lr.startColor = Color.magenta;
        lr.endColor = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        if (mono != null)
        {
            Vector2 vel = rb.velocity;
            float lengthNormalized = vel.magnitude / mono.speed;
            lr.SetPosition(1, (Vector2)transform.position + rb.velocity.normalized * lengthNormalized * displayLength);
        }
        else
        {
            lr.SetPosition(1, transform.position);
        }
    }
}
