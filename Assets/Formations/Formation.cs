using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Formation
{
    public abstract void AssignFormationPositions(List<Subordinate> subs, float spacing);
    public abstract List<Squad> Squads {get; set;}

}
