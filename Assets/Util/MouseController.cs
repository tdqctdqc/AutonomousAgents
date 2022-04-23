using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static MouseController Instance;
    TargetController tc; 
    Camera currentCamera;

    public Vector3 mousePos => GetMousePos();

    Vector3 GetMousePos() 
    {
        Vector3 mousePos = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; 
        return mousePos; 
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        currentCamera = FindObjectOfType<CameraScript>().gameObject.GetComponent<Camera>();
        tc = FindObjectOfType<TargetController>();
        mouseLeftDownDelegate = MouseLeftDown;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseClicks();
    }


    void HandleMouseClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseLeftDownDelegate();
        }
        if (Input.GetMouseButtonDown(1))
        {
            MouseRightDown();
        }
    }
    void MouseLeftDown()
    {

    }

    void MouseRightDown()
    {
        tc.SetDir(mousePos);
    }

    public delegate void MouseLeftDownDelegate();
    public MouseLeftDownDelegate mouseLeftDownDelegate;

    public void ClearMouseDelegates()
    {
        mouseLeftDownDelegate = null; 
        mouseLeftDownDelegate = MouseLeftDown;
    }
}
