using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    Rigidbody2D rb;
    public float force; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDir(Vector3 pos)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(force * (pos - transform.position).normalized);
    }
}
