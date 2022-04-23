using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLine : Formation
{

    GroupController group;
    Squad squad; 
    public FLine (GroupController group, Squad squad)
    {
        this.group = group;
        this.squad = squad;
        Squads = new List<Squad>();
    }
    public FLine(GroupController group)
    {
        this.group = group;
        Squads = new List<Squad>();

        BuildSquads();
    }


    public override List<Squad> Squads { get; set; }

    public override void AssignFormationPositions(List<Subordinate> subs, float spacing)
    {
        //BuildSquads();
        BuildLine(subs, spacing, group);
    }



    public void BuildSquads ()
    {

        Squad squad1 = new Squad(Squads.Count, group, Vector3.zero);
        Squads.Add(squad1);
    }
    public void BuildLine(List<Subordinate> subs, float spacing, GroupController group)
    {
        if (subs.Count % 2 == 0)
        {
            for (int i = 0; i < subs.Count; i += 2)
            {
                float xPos = (i / 2 + .5f) * spacing;
                subs[i].SetFormationPosition(new Vector3(xPos, 0f, 0f));
                subs[i + 1].SetFormationPosition(new Vector3(-xPos, 0f, 0f));
                
            }
        }
        else
        {
            subs[0].SetFormationPosition(Vector3.zero);
            for (int i = 1; i < subs.Count; i += 2)
            {
                float xPos = ((i + 1) / 2) * spacing;
                subs[i].SetFormationPosition(new Vector3(xPos, 0f, 0f));
                subs[i + 1].SetFormationPosition(new Vector3(-xPos, 0f, 0f));
            }
        }
    }

}
