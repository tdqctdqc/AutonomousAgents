using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupSidebarButton : MonoBehaviour
{
    GroupController controller;
    GroupSidebar sidebar;
    public Text text; 
    // Start is called before the first frame update
    void Start()
    {
        sidebar = GetComponentInParent<GroupSidebar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sidebar.manager.selector.AddSelectGroup(controller);
        }
        else
        {
            sidebar.manager.selector.SelectSingleGroup(controller);
        }

    }
    public void SetController(GroupController controller)
    {
        this.controller = controller;
        text.text = controller.groupName;
    }
    
}
