using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUi : MonoBehaviour
{

    public StarterAssets.ThirdPersonController player;
    [SerializeField] PhotoCapture photoCapture;
    [SerializeField] CursorManager cursorManager;

    [Header("things to turn off")]
    public MonoBehaviour playerControl;
    public GameObject photoControl;
    public GameObject animator;
    

    public GameObject objCanvas;

    public bool openOrClosed;
    // Start is called before the first frame update
    void Start()
    {
        openOrClosed = true;
        objCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && openOrClosed)
        {
            cursorManager.showCursor();
            photoControl.GetComponent<PhotoMode>().enabled = false;
            player.MoveSpeed = 0;
            player.SprintSpeed = 0;
            animator.GetComponent<Animator>().Play("Idle Walk Run Blend", 0, 0f);
            animator.GetComponent<Animator>().SetFloat("Speed", 0);
            playerControl.enabled = false;


            objCanvas.SetActive(true);
            openOrClosed = false;
        }

        else if (Input.GetKeyDown(KeyCode.Tab) && !openOrClosed)
        {
            cursorManager.hideCursor();
            player.MoveSpeed = 2;
            player.SprintSpeed = 5.335f;
            playerControl.enabled = true;
            photoControl.GetComponent<PhotoMode>().enabled = true;
           
            objCanvas.SetActive(false);
            openOrClosed = true;
        }


    }
}
