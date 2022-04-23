using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPainter 
{
 
    GroupController group;
    static List<Color> squadColors = squadColors = new List<Color>()
        {   Color.red,
            Color.blue,
            Color.green,
            Color.yellow,
            Color.magenta,
            Color.cyan,
            Color.grey,
            Color.white,
            Color.black
        };


    public AgentPainter (GroupController group)
    {
        this.group = group; 

    }
    

    public void PaintAgents()
    {
        foreach (Subordinate sub in group.subordinates)
        {
            sub.mono.agentColor.SetAgentColor(group.groupColor);
            int colorInt = sub.Squad.squadID;
            if (colorInt < squadColors.Count)
            {
                if(sub.mono == null)
                {
                    Debug.Log(sub.gameObject.name);
                }
                else
                {
                    sub.mono.squadColor.SetSquadRingColor(squadColors[colorInt]);
                }
                
                
            }
            else
            {
                Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
                squadColors.Add(newColor);
                sub.mono.squadColor.SetSquadRingColor(newColor);
            }
        }
    }
}
