using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan
{
    public List<Order> orderList;
    public Order currentOrder => GetCurrentOrder();
    Order defaultOrder = new OGetInFormation();
    public Plan(List<Order> orderList)
    {
        this.orderList = orderList;
    }
    public Plan(Order order)
    {
        List<Order> orderList = new List<Order>() { order };
        this.orderList = orderList;
    }

    public void DoneWithOrder()
    {
        if (orderList.Count > 1)
        {
            orderList.RemoveAt(0);
        }
        else
        {
            orderList = new List<Order>() { new OGetInFormation(new OCIndefinite()) } ;
        }
    }

    Order GetCurrentOrder()
    {
        if (orderList.Count > 0)
        {
            return orderList[0];
        }
        else
        {
            return null; 
        }
    }
}
