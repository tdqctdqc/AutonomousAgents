using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BehaviorManager : MonoBehaviour
{

    BehaviorWeight ArriveWeight;
    BehaviorWeight AvoidWeight;
    BehaviorWeight AvoidCollisionWeight;
    BehaviorWeight AvoidCollisionNormalWeight;
    BehaviorWeight EvadeWeight;
    BehaviorWeight PursueWeight;
    BehaviorWeight PursueArriveWeight; 
    BehaviorWeight SeekWeight;
    BehaviorWeight WanderWeight;
    BehaviorWeight CohesionWeight;
    BehaviorWeight AlignmentWeight;
    BehaviorWeight SeparationWeight;
    BehaviorWeight StayInFormationWeight; 


    public List<BehaviorWeight> weights { get; private set; }

    public BehaviorProfile bProfile = new BehaviorProfile(0,0,0,0,0,0,0,0,0,0,0,0,0); 

    private void Awake()
    {
        BuildWeights();
        BuildBehaviors();
        BuildWeightsList();
     }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BuildWeightsList ()
    {
        weights = new List<BehaviorWeight>();
        weights.Add(AvoidWeight);
        weights.Add(AvoidCollisionWeight);
        weights.Add(AvoidCollisionNormalWeight);
        weights.Add(EvadeWeight);
        weights.Add(PursueWeight);
        weights.Add(PursueArriveWeight); 
        weights.Add(SeekWeight);
        weights.Add(WanderWeight);
        weights.Add(CohesionWeight);
        weights.Add(AlignmentWeight);
        weights.Add(SeparationWeight);
        weights.Add(StayInFormationWeight);
    }


    void BuildWeights ()
    {
        ArriveWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        AvoidWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        AvoidCollisionWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        AvoidCollisionNormalWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        EvadeWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        PursueWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        PursueArriveWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        SeekWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        WanderWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        CohesionWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        AlignmentWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        SeparationWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
        StayInFormationWeight = ScriptableObject.CreateInstance("BehaviorWeight") as BehaviorWeight;
    }

    void BuildBehaviors ()
    {
        GameObject bObject = gameObject.GetComponentInChildren<BehaviorsObject>().gameObject;

        ArriveWeight.behavior = bObject.AddComponent<BArrive>();
        AvoidWeight.behavior = bObject.AddComponent<BAvoid>();
        AvoidCollisionWeight.behavior = bObject.AddComponent<BAvoidCollision>();
        AvoidCollisionNormalWeight.behavior = bObject.AddComponent<BAvoidCollisionNormal>();
        EvadeWeight.behavior = bObject.AddComponent<BEvade>();
        PursueWeight.behavior = bObject.AddComponent<BPursue>();
        PursueArriveWeight.behavior = bObject.AddComponent<BPursueArrive>();
        SeekWeight.behavior = bObject.AddComponent<BSeek>();
        WanderWeight.behavior = bObject.AddComponent<BWander>();
        CohesionWeight.behavior = bObject.AddComponent<BCohesion>();
        AlignmentWeight.behavior = bObject.AddComponent<BAlignment>();
        SeparationWeight.behavior = bObject.AddComponent<BSeparation>();
        StayInFormationWeight.behavior = bObject.AddComponent<BStayInFormation>();
    }

    void UpdateWeights() 
    {
        ArriveWeight.weight = bProfile.arrive;
        AvoidWeight.weight = bProfile.avoid;
        AvoidCollisionWeight.weight = bProfile.avoidCol;
        AvoidCollisionNormalWeight.weight = bProfile.avoidColNor;
        EvadeWeight.weight = bProfile.evade;
        PursueWeight.weight = bProfile.pursue;
        PursueArriveWeight.weight = bProfile.pursueArrive;
        SeekWeight.weight = bProfile.seek;
        WanderWeight.weight = bProfile.wander;
        CohesionWeight.weight = bProfile.cohes;
        AlignmentWeight.weight = bProfile.align;
        SeparationWeight.weight = bProfile.separ;
        StayInFormationWeight.weight = bProfile.form;
    }

    public void GetBehaviorProfile (Order order)
    {
        bProfile = order.bProfile;
        UpdateWeights();
    }
}
