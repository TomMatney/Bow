using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Restocker : MonoBehaviour
{
    public StarterAssets.ThirdPersonController player;
   

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase stockCam;

    public bool isInArea;

    public bool inOut;

    // Start is called before the first frame update
    void Start()
    {
        isInArea = false;
        inOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInArea )
        {
            isInArea = false;
            inOut = true;
            stockCam.Priority = 11;
            player.MoveSpeed = 0;
            player.SprintSpeed = 0;
            
        }
        else if(Input.GetKeyDown(KeyCode.E) && inOut)
        {
            isInArea = true;
            inOut = false;
            stockCam.Priority = 8;
            player.MoveSpeed = 2;
            player.SprintSpeed = 5.335f;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        isInArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        stockCam.Priority = 8;
        isInArea = false;
        inOut = false;
    }
}
