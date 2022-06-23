using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RightClick : MonoBehaviour
{
    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoom;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            zoom.Priority = 11;
            Debug.Log("zoom");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            zoom.Priority = 9;
        }

    }
}
