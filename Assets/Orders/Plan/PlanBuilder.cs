using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlanBuilder
{
    static List<Order> GetOrders(params Order[] orders)
    {
        List<Order> newOrderList = new List<Order>(); 
        for (int i = 0; i < orders.Length; i++)
        {
            newOrderList.Add(orders[i]);
        }
        return newOrderList;
    }
    static Plan BuildPlan(List<Order> orderList)
    {
        Plan plan = new Plan(orderList);
        return plan; 
    }
    public static Plan Plan(params Order[] orders)
    {
        return BuildPlan(GetOrders(orders));
    }
    public static Plan ReturnPlan(List<Order> orders)
    {
        return BuildPlan(orders);
    }

}
