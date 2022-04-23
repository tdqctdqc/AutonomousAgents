using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWedge : Formation
{
    GroupController group;
    Squad squad; 
    public FWedge(GroupController group, Squad squad)
    {
        this.group = group;
        this.squad = squad; 
        Squads = new List<Squad>();
    }
    public FWedge(GroupController group)
    {
        this.group = group;
        Squads = new List<Squad>();
        BuildSquads();
    }
    public override List<Squad> Squads { get; set; }

    public override void AssignFormationPositions(List<Subordinate> subs, float spacing)
    {
        BuildWedge(subs, spacing, group);
    }

    public void BuildSquads()
    {
        Squad squad1 = new Squad(1, group, Vector3.zero);
        Squads.Add(squad1);
    }
    public void BuildWedge(List<Subordinate> subs, float spacing, GroupController group)
    {
        
        if (subs.Count % 2 == 0)
        {
            for (int i = 0; i < subs.Count; i += 2)
            {
                float xPos = (i / 2 + .5f) * spacing;
                float yPos = -Mathf.Abs(xPos) / 3f;
                subs[i].SetFormationPosition(new Vector3(xPos, yPos, 0f));
                subs[i + 1].SetFormationPosition(new Vector3(-xPos, yPos, 0f));
                //subs[i].SetSquad(Squads[0]);
                //subs[i + 1].SetSquad(Squads[0]);
            }
        }
        else
        {
            subs[0].SetFormationPosition(Vector3.zero);
            for (int i = 1; i < subs.Count; i += 2)
            {
                float xPos = ((i + 1) / 2) * spacing;
                float yPos = -Mathf.Abs(xPos);
                subs[i].SetFormationPosition(new Vector3(xPos, yPos, 0f));
                subs[i + 1].SetFormationPosition(new Vector3(-xPos, yPos, 0f));
                //subs[i].SetSquad(Squads[0]);
                //subs[i + 1].SetSquad(Squads[0]);
            }
        }
    }
}
