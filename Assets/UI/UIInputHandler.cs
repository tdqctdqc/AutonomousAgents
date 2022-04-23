using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputHandler : MonoBehaviour
{
    public static UIInputHandler Instance; 

    



    public CommandBar commandBar { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        commandBar = GetComponentInChildren<CommandBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
