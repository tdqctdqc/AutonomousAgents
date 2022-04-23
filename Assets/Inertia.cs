using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inertia : MonoBehaviour
{
    Rigidbody2D rb;
    float refreshTime = .1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Tick());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity *= .95f / (1f - Time.deltaTime); 
    }

    IEnumerator Tick()
    {
        while (true)
        {
            rb.velocity *= .95f;
            yield return new WaitForSeconds(refreshTime);
        }
    }
}
