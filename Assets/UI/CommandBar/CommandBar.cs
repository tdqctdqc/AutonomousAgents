using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBar : MonoBehaviour
{
    GroupManager manager;
    MouseController mouseController;
    bool planMode = false;
    List<Order> orderCache; 
    private void Start()
    {
        manager = FindObjectOfType<GroupManager>();
        mouseController = FindObjectOfType<MouseController>();
    }

    public void StartPlanMode()
    {
        planMode = true;
        orderCache = new List<Order>();
    }
    public void EndPlanMode()
    {
        planMode = false;
        Plan plan = PlanBuilder.ReturnPlan(orderCache);
        manager.GivePlanToGroups(plan);
    }

    public void GroupGoToLocation()
    {
        if (planMode == false)
        {
            mouseController.ClearMouseDelegates();
            mouseController.mouseLeftDownDelegate += GroupGoToLocationClick; 
        }
        else
        {
            mouseController.ClearMouseDelegates();
            mouseController.mouseLeftDownDelegate += GroupGoToLocationClickPlan;
        }
        
    }
    public void GroupGoToLocationClick()
    {
        OGoToLocation goOrder = new OGoToLocation(mouseController.mousePos);
        manager.GiveOrderToGroups(goOrder);
        mouseController.mouseLeftDownDelegate -= GroupGoToLocationClick;
    }
    public void GroupGoToLocationClickPlan ()
    {
        orderCache.Add(new OGoToLocation(mouseController.mousePos));
        mouseController.mouseLeftDownDelegate -= GroupGoToLocationClickPlan;
    }
    public void GroupChaseObject()
    {
        if (planMode == false)
        {
            OChaseGameObject chaseOrder = new OChaseGameObject(manager.target, Vector3.zero);
            manager.GiveOrderToGroups(chaseOrder);
        }
        else
        {
            orderCache.Add(new OChaseGameObject(manager.target, Vector3.zero));
        }
    }

    public void GroupGetInFormation()
    {
        if (planMode == false)
        {
            OGetInFormation formOrder = new OGetInFormation();
            manager.GiveOrderToGroups(formOrder);
        }
        else
        {
            orderCache.Add(new OGetInFormation());
        }
    }

    public void GroupWander()
    {
        if (planMode == false)
        {
            OWander wanderOrder = new OWander(new Vector3(0f, 0f, 0f));
            manager.GiveOrderToGroups(wanderOrder);
        }
        else
        {
            orderCache.Add(new OWander(new Vector3(0f, 0f, 0f)));
        }
    }
}
