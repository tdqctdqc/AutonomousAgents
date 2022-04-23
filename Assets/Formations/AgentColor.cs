using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentColor : MonoBehaviour
{
    SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAgentColor (Color c)
    {
        SR.color = c; 
    }
}
