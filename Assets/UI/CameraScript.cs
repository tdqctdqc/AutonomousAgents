using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    Camera parentCamera; 
    public GameObject target;
    public float followDist; 
    void Start()
    {
        parentCamera = GetComponent<Camera>();
        followDist = parentCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }


    void GetInput()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            if (parentCamera.orthographicSize > 1)
            {
                parentCamera.orthographicSize -= 1;
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (parentCamera.orthographicSize < 30)
            {
                parentCamera.orthographicSize += 1;
            }
        }




        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-parentCamera.orthographicSize / 2f, 0 , 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(parentCamera.orthographicSize / 2f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0,parentCamera.orthographicSize / 2f,  0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -parentCamera.orthographicSize / 2f, 0);
        }
    }
}
