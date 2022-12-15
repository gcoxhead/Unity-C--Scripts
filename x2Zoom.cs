using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class x2Zoom : MonoBehaviour
{
    public Camera cam;
    public float defaultFov = 90;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cam.fieldOfView = (defaultFov / 2);
            Debug.Log("Left mouse clicked.");

        }
        else
        {
            cam.fieldOfView = (defaultFov);
        }
    }
}
