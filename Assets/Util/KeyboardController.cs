using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    UIInputHandler uiHandler; 
    // Start is called before the first frame update
    void Start()
    {
        uiHandler = UIInputHandler.Instance; 
    }

    // Update is called once per frame
    void Update()
    {
        LeftControl();
    }

    void LeftControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            uiHandler.commandBar.StartPlanMode();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            uiHandler.commandBar.EndPlanMode();
        }
    }

    
}
