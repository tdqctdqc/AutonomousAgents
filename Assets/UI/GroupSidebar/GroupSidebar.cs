using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSidebar : MonoBehaviour
{
    public GroupManager manager { get; private set; }
    public GameObject buttonPrefab;
    List<GroupSidebarButton> buttons; 
    // Start is called before the first frame update
    void Start()
    {
        buttons = new List<GroupSidebarButton>();
        manager = FindObjectOfType<GroupManager>();
        BuildButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildButtons()
    {
        foreach (var groupController in manager.groups)
        {
            GameObject buttonOb = Instantiate(buttonPrefab, transform);
            var button = buttonOb.GetComponent<GroupSidebarButton>();
            button.SetController(groupController);
            buttons.Add(button);
        }
    }
}
