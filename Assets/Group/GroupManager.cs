using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public List<GroupController> groups;
    public List<GroupController> selectedGroups;
    public GameObject target;
    public GroupSelector selector;

    private void Awake()
    {
        selector = new GroupSelector(this);
        selectedGroups = new List<GroupController>() { groups[0] };
    }
    private void Update()
    {
        selector.CheckIfNumberKeyPressed();
    }

    public void GiveOrderToGroups(Order order)
    {
        Plan plan = new Plan(order);
        GivePlanToGroups(plan);
    }

    public void GivePlanToGroups (Plan plan)
    {
        foreach (var group in selectedGroups)
        {
            group.orderHandler.GetPlan(plan);
        }
    }
}
