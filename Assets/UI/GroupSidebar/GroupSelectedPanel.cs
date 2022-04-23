using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupSelectedPanel : MonoBehaviour
{

    GroupController group; 
    Text text;
    bool set = false;

    UIGroupSelectedName groupName;
    UIGroupSelectedCount count;
    UIGroupSelectedFormation formation;
    UIGroupSelectedOrder order; 

    // Start is called before the first frame update
    void Start()
    {
        group.groupUIStatsChanged += UpdatePanel;
    }

    // Update is called once per frame
    void Update()
    {
        if(set)
        {
        }
    }

    public void Set(GroupController group)
    {
        this.group = group;

        groupName = GetComponentInChildren<UIGroupSelectedName>();
        count = GetComponentInChildren<UIGroupSelectedCount>();
        formation = GetComponentInChildren<UIGroupSelectedFormation>();
        order = GetComponentInChildren<UIGroupSelectedOrder>();

        UpdatePanel();
        set = true; 
    }

    public void UpdatePanel()
    {
        groupName.text.text = group.groupName;
        count.text.text = group.subordinates.Count.ToString();
        formation.text.text = group.formation.ToString();

        if (group.order != null)
        {
            order.text.text = group.order.ToString();
        }
        else
        {
            order.text.text = "No Order";
        }

    }
    private void OnDestroy()
    {
        group.groupUIStatsChanged -= UpdatePanel;
    }
}
