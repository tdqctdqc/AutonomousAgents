using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorMono : MonoBehaviour
{
    public BehaviorCalculator calc { get; private set; }
    public float speed;
    public Rigidbody2D RB { get; private set; }
    public Collider2D Col { get; private set; }
    public Steerer Steerer { get; private set; }
    public Crosshair Crosshair { get; private set; }
    public Vector3 TargetPos => sub.order.target.GetTarget; 

    public GameObject TargetObject { get; private set; }
    public Rigidbody2D TargetRB => sub.order.target.targetRB;
    public Flocker Flocker { get; private set; } 
    public BehaviorManager Manager { get; private set;}

    public Subordinate sub { get; private set; }

    public AgentColor agentColor { get; private set; }
    public SquadRing squadColor { get; private set; }


    bool set = false;


    // Start is called before the first frame update
    private void Awake()
    {
        Manager = GetComponent<BehaviorManager>();

        Steerer = GetComponent<Steerer>();

        Flocker = gameObject.GetComponent<Flocker>();
        Col = gameObject.GetComponent<Collider2D>();

        RB = GetComponent<Rigidbody2D>();
        Crosshair = GetComponentInChildren<Crosshair>();
    }
    void Start()
    {
        Crosshair = GetComponentInChildren<Crosshair>();

        calc = new BehaviorCalculator(this, Steerer, Crosshair);

        sub = GetComponent<Subordinate>();

        agentColor = GetComponentInChildren<AgentColor>();
        squadColor = GetComponentInChildren<SquadRing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(set == false)
        {
            set = true;
        }
        else
        {

            calc.DoBehaviors();
        }
    }

}
