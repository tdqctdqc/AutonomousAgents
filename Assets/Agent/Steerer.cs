using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steerer : MonoBehaviour
{
    float maxSpeed = 10f; 
    Rigidbody2D rb;
    SteeringArrow steerArrow;
    Vector3 cachedForce;
    float interpolationConst = .05f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        steerArrow = GetComponentInChildren<SteeringArrow>();
        cachedForce = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        rb.angularVelocity = 0f; 
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void AddForce (Vector3 force)
    {

        Vector3 lerpForce = Vector3.Lerp(cachedForce, force, interpolationConst);
        rb.AddForce(lerpForce);
        steerArrow.SetSteeringArrow(transform.position + lerpForce);
        cachedForce = lerpForce; 
    }
}
