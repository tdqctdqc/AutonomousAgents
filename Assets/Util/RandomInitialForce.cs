using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInitialForce : MonoBehaviour
{

    Rigidbody2D rb;
    public float minForce = 5f;
    public float maxForce = 10f;
    bool didIt = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (didIt == false)
        {
            Vector3 randVector = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f));
            float randMagnitude = Random.Range(minForce, maxForce);
            Vector3 force = randVector * randMagnitude;
            rb.AddForce(force);
            didIt = true;
        }
    }
}
