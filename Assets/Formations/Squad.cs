using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad 
{

    public Squad(int id, GroupController group, Vector3 displace)
    {
        squadMembers = new List<Subordinate>();
        squadID = id;
        this.group = group;
        this.displace = displace * group.spacing;
    }

    public void SetFormation (Formation formation)
    {
        this.formation = formation; 
    }


    public List<Subordinate> squadMembers;

    public int squadID { get; private set; }
    public Vector3 SquadCenter => GetSquadCenter();
    Vector3 displace;
    //public Quaternion groupRot => Quaternion.FromToRotation(Vector3.up, group.order.target.TargetCoordinates - group.FormationAnchor);
    public Quaternion groupRot =>    Quaternion.FromToRotation(Vector3.up, group.FormationHeading);
    public Vector3 SquadAnchor => group.FormationAnchor + groupRot * displace; 

    public Formation formation { get; private set; }
    GroupController group;
    float spacing => group.spacing;




    //anchor it still to formation CoG but w offset? 
    public Vector3 GetSquadCenter()
    {
            Vector3 avg = new Vector3(0, 0, 0);
            for (int i = 0; i < squadMembers.Count; i++)
            {
                avg += squadMembers[i].transform.position;
            }
            avg = (1f / squadMembers.Count) * avg;
            return avg;
    }

    internal void RegisterInSquad(Subordinate subordinate)
    {
        squadMembers.Add(subordinate);
    }

    public void AssignSquadPositions ()
    {
        formation.AssignFormationPositions(squadMembers, spacing);
    }
}
