using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHandler
{
    GroupController group;

    public Plan plan;

    public OrderHandler(GroupController group)
    {
        this.group = group;
        InitPlan();
    }


    void InitPlan()
    {
        Order startOrder = new OGetInFormation();
        Order goOrder = new OGoToLocation(group.FormationAnchor + Vector3.up * 10f);
        Order formOrder = new OGetInFormation();
        Plan plan = PlanBuilder.Plan(startOrder, goOrder, formOrder);
        GetPlan(plan);
    }

    public void GetPlan(Plan plan)
    {
        this.plan = plan;
        GetOrder(plan.currentOrder);
    }

    public void CheckIfOrderCompleted()
    {
        bool complete = plan.currentOrder.completeCondition.CheckCompleted(group);

        if (complete)
        {
            plan.DoneWithOrder();
            GetOrder(plan.currentOrder);
        }
    }

    public void GetOrder(Order order)
    {
        group.StopCoroutine(group.SetFormationHeadingRoutine());
        group.ReceiveOrder(order);
        
        if (order is OGetInFormation == false)
        {
            group.SetFormationHeading(order.target.TargetCoordinates);
        }
        else
        {
            return; 
        }
        if (order.target.hasObjectAsTarget)
        {
            group.StartCoroutine(group.SetFormationHeadingRoutine());
        }
    }
}
