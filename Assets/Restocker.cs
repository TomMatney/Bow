using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Restocker : MonoBehaviour
{
    public StarterAssets.ThirdPersonController player;

    [SerializeField] PhotoCapture photoCapture;
    [SerializeField] CursorManager cursorManager;
   

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase stockCam;

    public CinemachineVirtualCameraBase labtopCam;





    public bool isInArea;

    public bool inOut;

    public bool stockOrLabtop;

    [Header("things to turn off")]
    public MonoBehaviour playerControl;
    public GameObject photoControl;
    public GameObject animator;
    public GameObject photoDatabaseUi;
    

   

    // Start is called before the first frame update
    void Start()
    {
        stockOrLabtop = true;
        isInArea = false;
        inOut = false;
        //photoDatabaseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && stockOrLabtop && inOut)
        {
            stockOrLabtop = false;
            stockCam.Priority = 8;
            labtopCam.Priority = 11;
            
        }
        else if (Input.GetKeyDown(KeyCode.D) && !stockOrLabtop && inOut)
        {
            
            stockOrLabtop = true;
            labtopCam.Priority = 8;
            stockCam.Priority = 11;
           
        }
        

        if (Input.GetKeyDown(KeyCode.E) && isInArea )
        {
            cursorManager.showCursor();
            isInArea = false;
            inOut = true;
            stockCam.Priority = 11;
            photoControl.GetComponent<PhotoMode>().enabled = false;
            player.MoveSpeed = 0;
            player.SprintSpeed = 0;
            animator.GetComponent<Animator>().Play("Idle Walk Run Blend", 0, 0f);
            animator.GetComponent<Animator>().SetFloat("Speed", 0);
            playerControl.enabled = false;
            reStock();
            //photoDatabaseUi.SetActive(true);


        }
        else if(Input.GetKeyDown(KeyCode.E) && inOut)
        {
            cursorManager.hideCursor();
            isInArea = true;
            inOut = false;
            stockCam.Priority = 8;
            player.MoveSpeed = 2;
            player.SprintSpeed = 5.335f;
            playerControl.enabled = true;
            photoControl.GetComponent<PhotoMode>().enabled = true;
            //photoDatabaseUi.SetActive(false);
            labtopCam.Priority = 8;
            vcam.Priority = 11;

        }    
    }
    private void reStock()
    {
        photoCapture.pictureStock = 15;
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
