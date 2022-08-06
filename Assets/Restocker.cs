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

    [Header("things to turn off")]
    public MonoBehaviour playerControl;
    public GameObject photoControl;
    public GameObject animator;
    

   

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
            photoControl.GetComponent<PhotoMode>().enabled = false;
            player.MoveSpeed = 0;
            player.SprintSpeed = 0;
            animator.GetComponent<Animator>().Play("Idle Walk Run Blend", 1, 0f);
            animator.GetComponent<Animator>().SetFloat("Speed", 0);
            playerControl.enabled = false;


        }
        else if(Input.GetKeyDown(KeyCode.E) && inOut)
        {
            isInArea = true;
            inOut = false;
            stockCam.Priority = 8;
            player.MoveSpeed = 2;
            player.SprintSpeed = 5.335f;
            playerControl.enabled = true;
            photoControl.GetComponent<PhotoMode>().enabled = true;


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
