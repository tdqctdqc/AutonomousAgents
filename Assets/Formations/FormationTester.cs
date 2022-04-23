using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationTester : MonoBehaviour
{
    public GameObject marker;
    GameObject markerDummy => marker; 
    public int number;
    public int frontage; 
    public float spacing; 
    // Start is called before the first frame update
    void Start()
    {
        Vector3[,] positions = new Vector3[frontage, number % frontage + 1];
        int x = 0;
        int y = 0;
        for (int i = 0; i < number; i++)
        {
            GameObject newMarker = Instantiate(marker, gameObject.transform);
            newMarker.transform.position = positions[x, y];
            newMarker.name = (i+1).ToString();
            if (x < frontage - 1 )
            {
                x += 1;
            }
            else
            {
                x = 0;
                y += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
