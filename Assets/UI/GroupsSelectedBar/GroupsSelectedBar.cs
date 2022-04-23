using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsSelectedBar : MonoBehaviour
{
    GroupManager manager;
    public GameObject groupPanelPrefab;
    List<GroupSelectedPanel> panels = new List<GroupSelectedPanel>();
    bool init = false; 

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GroupManager>();
        manager.selector.changedGroupSelection += UpdateGroupSelected;
    }

    // Update is called once per frame
    void Update()
    {
        if (init == false)
        {
            init = true;
        }
    }

    void UpdateGroupSelected()
    {
        foreach (var panel in panels)
        {
            Destroy(panel.gameObject);
        }

        panels = new List<GroupSelectedPanel>();
        foreach (var group in manager.selectedGroups)
        {
            if(group != null)
            {
                BuildGroupPanel(group);
            }
        }
    }

    void BuildGroupPanel(GroupController group)
    {
        GameObject newPanel = Instantiate(groupPanelPrefab, transform);
        GroupSelectedPanel newPanelScript = newPanel.GetComponent<GroupSelectedPanel>();
        newPanelScript.Set(group);
        panels.Add(newPanelScript);
    }
}
