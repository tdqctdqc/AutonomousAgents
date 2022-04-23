using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSelector
{
    List<GroupController> selectedGroups => manager.selectedGroups;
    List<GroupController> groups => manager.groups;
    public GroupSelector(GroupManager manager)
    {
        this.manager = manager;
        changedGroupSelection = ChangedGroupSelectionFunction;
    }
    GroupManager manager;

    public void AddSelectGroup(int i)
    {
        if (selectedGroups.Contains(groups[i]) == false)
        {
            selectedGroups.Add(groups[i]);
            changedGroupSelection();
        }
    }
    public void AddSelectGroup(GroupController gc)
    {
        if (selectedGroups.Contains(gc) == false)
        {
            selectedGroups.Add(gc);
            changedGroupSelection();
        }
    }
    public void SelectSingleGroup(GroupController gc)
    {
        manager.selectedGroups = new List<GroupController>() { gc };
        changedGroupSelection();
    }
    public void SelectSingleGroup(int i)
    {
        manager.selectedGroups = new List<GroupController>() { groups[i] };
        changedGroupSelection();
    }

    
    public void CheckIfNumberKeyPressed ()
    {
        for (int i = 1; i < 10; ++i)
        {
            if (Input.GetKeyDown("" + i) && groups.Count >= i)
            {
                SelectSingleGroup(i-1);
            }
        }
    }

    public delegate void ChangedGroupSelection();
    public ChangedGroupSelection changedGroupSelection;
    private void ChangedGroupSelectionFunction()
    {

    }
}
