using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationBar : MonoBehaviour
{
    public GroupManager manager; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PyramidButton ()
    {
        for (int i = 0; i < manager.selectedGroups.Count; i++)
        {
            manager.selectedGroups[i].formationController.BuildPyramidFormation();
        }
    }
    public void BlocButton()
    {
        for (int i = 0; i < manager.selectedGroups.Count; i++)
        {
            manager.selectedGroups[i].formationController.BuildBlocFormation();
        }
    }
    public void LineButton()
    {
        for (int i = 0; i < manager.selectedGroups.Count; i++)
        {
            manager.selectedGroups[i].formationController.BuildLineFormation();
        }
    }
    public void WedgeButton()
    {
        for (int i = 0; i < manager.selectedGroups.Count; i++)
        {
            manager.selectedGroups[i].formationController.BuildWedgeFormation();
        }
    }
    public void ColumnButton()
    {
        for (int i = 0; i < manager.selectedGroups.Count; i++)
        {
            manager.selectedGroups[i].formationController.BuildColumnFormation();
        }
    }
}
