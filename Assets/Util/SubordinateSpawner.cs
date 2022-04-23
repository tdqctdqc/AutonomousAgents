using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubordinateSpawner : MonoBehaviour
{

    public GameObject subordinatePrefab;
    [SerializeField] int number = 1;
    [SerializeField] GroupController group;
    List<Subordinate> subordinates;
    // Start is called before the first frame update
    void Start()
    {
        if (group == null)
        {
            group = GetComponent<GroupController>();
        }
        SpawnSubordinates();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnSubordinates()
    {
        subordinates = new List<Subordinate>();
        for (int i = 0; i < number; i++)
        {
            Subordinate sub = Instantiate(subordinatePrefab, group.transform).GetComponent<Subordinate>();
            subordinates.Add(sub);
            sub.gameObject.name = group.groupName + " " + i.ToString();
            sub.SetFaction(group.Faction);
        }
        group.GetSubordinates(subordinates);
    }
}
