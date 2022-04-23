using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPyramid : Formation 
{
    public override List<Squad> Squads { get; set; }
    GroupController group;
    public FPyramid(GroupController group)
    {
        this.group = group;
    }
    public override void AssignFormationPositions(List<Subordinate> subs, float spacing)
    {
        BuildPyramid(subs.Count, spacing);
        AssignSquads(subs, Squads);
    }


    public void BuildPyramid(int number, float spacing)
    {
        BuildSquads(number);
    }

    void BuildSquads(int number)
    {
        Squads = new List<Squad>();
        int squadNumber = CalculateNumSquads(number);
        for (int i = 0; i < squadNumber; i++)
        {
            Squad newSquad = new Squad(i, group, new Vector3(0, -i, 0));
            Squads.Add(newSquad);
            FLine line = new FLine(group, newSquad);
            newSquad.SetFormation(line);
        }
            
        
    }

    int CalculateNumSquads( int number)
    {
        int i = 0;
        while (number > (i * (i + 1)) / 2 )
        {
            i += 1; 
        }
        return i; 
    }

    static void AssignSquads(List<Subordinate> subs, List<Squad> squads)
    {
        int toggle = 1; 
        for (int i = 0; i < subs.Count; i++)
        {
            float sol = (-1 + Mathf.Sqrt(1 + 2 * i));

            int squadNum;
            if (toggle == -1)
            {
                squadNum = Mathf.CeilToInt(sol);
            }
            else
            {
                squadNum = Mathf.FloorToInt(sol);
            }
            toggle *= -1;
            subs[i].SetSquad(squads[squadNum]);
        }

        for (int i = 0; i < squads.Count; i++)
        {
            squads[i].AssignSquadPositions();
        }
    }
}
