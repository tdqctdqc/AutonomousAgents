using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupController : MonoBehaviour
{
    public List<Subordinate> subordinates;
    public GameObject chaseTarget;
    public float spacing = 2f;
    public string groupName;
    public int frontage;


    public Order order; 
    public OrderHandler orderHandler;


    public GroupFormationController formationController { get; private set; }
    public Formation formation { get; private set; }
    public Vector3 FormationAnchor => GetAnchor();
    public Vector3 FormationHeading { get; private set; }


    public Color groupColor; 
    bool painted = false;
    AgentPainter painter; 

    [SerializeField] int faction = 0;
    public int Faction => faction; 

    void Awake()
    {
        groupColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        painter = new AgentPainter(this);

        groupUIStatsChanged = GroupUIStatsChangedFunction;
        FormationHeading = Vector3.up;
    }
    private void Start()
    {
        InitFormation();
        orderHandler = new OrderHandler(this);
        StartCoroutine(CheckIfOrderCompleteRoutine());
        
    }

    void Update()
    {
        if (painted == false)
        {
            Paint();
            painted = true; 
        }
    }
    public void SetFormation(Formation f)
    {
        formation = f;
        formation.AssignFormationPositions(subordinates, spacing);
        painted = false;
        if(groupUIStatsChanged != null)
        {
        groupUIStatsChanged();
        }
    }
    void Paint()
    {
        if (painter != null)
        {
            painter.PaintAgents();
        }
    }
    public void ReceiveOrder(Order order)
    {
        this.order = order; 
        if (subordinates.Count > 0)
        {
            ImplementOrder(order);
            groupUIStatsChanged();
        }
        
    }





    Vector3 GetAnchor()
    {
        Vector3 anchor;
        if (subordinates[0] == null)
        {
            anchor = Vector3.zero;
        }
        else
        {
            anchor = subordinates[0].Squad.GetSquadCenter();
        }
        return anchor;
    }
    public void GetSubordinates ( List<Subordinate> subs)
    {
        subordinates = subs;
        InitFormation();
        for (int i = 0; i < subordinates.Count; i++)
        {
            subordinates[i].groupController = this;
        }
    }

    public void InitFormation()
    {
        formationController = new GroupFormationController(this);
        formationController.BuildBlocFormation();
    }

    public void GiveOrderToAll(Order order)
    {
        for (int i = 0; i < subordinates.Count; i++)
        {
            if(subordinates[i] != null)
            {
                subordinates[i].GetOrder(order);
            }
            
        }
    }

    void ImplementOrder (Order order)
    {
        GiveOrderToAll(order);
        formation.AssignFormationPositions(subordinates, spacing);
    }

    public void SetFormationHeading(Vector3 target)
    {
        FormationHeading = (target - FormationAnchor).normalized; 
    }
    public IEnumerator SetFormationHeadingRoutine()
    {
        while (true)
        {
            if (order != null)
            {
                SetFormationHeading(order.target.TargetCoordinates);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator CheckIfOrderCompleteRoutine()
    {
        while (true)
        {
            orderHandler.CheckIfOrderCompleted();
            yield return new WaitForSeconds(.5f);
        }
    }


    public delegate void GroupUIStatsChanged();
    public GroupUIStatsChanged groupUIStatsChanged;
    private void GroupUIStatsChangedFunction()
    {

    }
}
