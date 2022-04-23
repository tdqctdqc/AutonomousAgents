using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subordinate : MonoBehaviour
{
    public GroupController groupController; 
    public BehaviorMono mono { get; private set; }
    public Vector3 formationPosition { get; private set; } //local space
    public Vector3 formationPositionAdjusted => squad.groupRot * formationPosition; 
    public Order order { get; private set; }
    [SerializeField] Squad squad;
    public Squad Squad => squad;

    [SerializeField] int faction;
    public int Faction => faction;
    public bool InFormation = false; 

    private void Awake()
    {
        mono = GetComponent<BehaviorMono>();
    }

    public void GetOrder(Order order)
    {
        this.order = order;
        mono.Manager.GetBehaviorProfile(order);
    }

    public void SetFormationPosition (Vector3 newPos)
    {
        formationPosition = newPos; 
    }

    public void SetSquad(Squad squad)
    {
        this.squad = squad; 
        squad.RegisterInSquad(this);
    }

    public void SetFaction (int faction)
    {
        this.faction = faction; 
    }

}
