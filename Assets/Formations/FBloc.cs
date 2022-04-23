using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FBloc : Formation
{
    int frontage;

    public override List<Squad> Squads { get; set; }
    GroupController group;
    public FBloc(int frontage, GroupController group)
    {
        this.frontage = frontage;
        this.group = group; 
    }
    public override void AssignFormationPositions(List<Subordinate> subs, float spacing)
    {
        BuildBloc(frontage, subs.Count, spacing);
        AssignSquads(subs, frontage, Squads);
    }


    public void BuildBloc(int frontage, int number, float spacing)
    {
        int x = frontage;
        int y = (int)Mathf.Ceil(number / frontage) + 1;

        BuildSquads(y);
    }

    void BuildSquads(int numSquads)
    {
        Squads = new List<Squad>();
        for (int i = 0; i < numSquads; i++)
        {
            Squad newSquad = new Squad(i, group, new Vector3 (0, -i, 0));
            FLine line = new FLine(group, newSquad);
            newSquad.SetFormation(line);
            Squads.Add(newSquad);
        }
    }

    static void AssignSquads(List<Subordinate> subs, int frontage, List<Squad> squads)
    {

        int x = 0;
        int y = 0;

        for (int i = 0; i < subs.Count; i++)
        {
            if (subs[i] != null)
            {
                subs[i].SetSquad(squads[y]);
            }

            if (x < frontage - 1)
            {
                x += 1;
            }
            else
            {
                x = 0;
                y += 1;
            }
        }




        for (int i = 0; i < squads.Count; i++)
        {
            squads[i].AssignSquadPositions();
        }
    }
}
