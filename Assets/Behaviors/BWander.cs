using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWander : Behavior
{
    Steerer steerer;
    Vector3 steerDir;
    Vector3 steerPoint;
    float wanderTimeInterval = .1f;
    float wanderStepInterval = 15f; //in degrees
    Crosshair crosshair;

    Rigidbody2D rb;

    BehaviorMono mono;
    bool set = false;
    public override string behaviorName => name;
    // Start is called before the first frame update
    void Start()
    {
        mono = GetComponentInParent<BehaviorMono>();
    }

    public override void Behave(float weight)
    {
        steerPoint = transform.position + steerDir.normalized * weight;
        AgentUtility.GoToSimple(mono.calc, transform.position, steerPoint, weight);
    }

    // Update is called once per frame
    void Update()
    {
        if (set == false)
        {
            rb = mono.RB;
            crosshair = mono.Crosshair;
            steerer = mono.Steerer;
            steerDir = Vector3.up;
            StartCoroutine(NewSteerDir());
            set = true;
        }
    }

    public static Quaternion IncrementSteerDir (Vector3 steerDir, Rigidbody2D callerRB, float wanderStepInterval)
    {
        return Quaternion.Euler(0, 0, wanderStepInterval * Random.Range(-2, 2));
    }

    IEnumerator NewSteerDir ()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                steerDir = IncrementSteerDir(steerDir, rb, wanderStepInterval) * steerDir;
                yield return new WaitForSeconds(wanderTimeInterval);
            }
        }
    }
}
