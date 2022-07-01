using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PhotoMode : MonoBehaviour
{
    [SerializeField] PhotoCapture photoCapture;

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoom;

    public GameObject projectile;
    public Transform projectileSpawnPoint;

    public StarterAssets.ThirdPersonController player;

    public float forcehold = 0f;

    private bool isPhotoModeOn;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //0 = left click 1 = right click
        //alt enter
        HandlePhotoModeInput();

        HandlePhotoCaptureInput();
    }

    private void HandlePhotoCaptureInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            photoCapture.OnClick(isPhotoModeOn);
            
            UiManager.singleton.ToggleCameraUi(true);
            
        }
    }

    private void HandlePhotoModeInput()
    {
        if (Input.GetMouseButtonDown(1)) //right click hold down zooms in
        {
            UiManager.singleton.ToggleCameraUi(true);
            player.SprintSpeed = 1;
            player.MoveSpeed = 1;
            zoom.Priority = 11;
            PhotoModeOn();
            Debug.Log("zoom");
        }
        else if (Input.GetMouseButtonUp(1)) //right click release zooms out
        {
            UiManager.singleton.ToggleCameraUi(false);
            player.SprintSpeed = 5.335f;
            player.MoveSpeed = 2;
            zoom.Priority = 9;
            isPhotoModeOn = false;
        }
    }

    private void PhotoModeOn()
    {
        isPhotoModeOn = true;
    }

   
    private void FireProjectile()
    {
        GameObject arrow = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        arrow.GetComponent<Projectile>().Setforce(forcehold);
        Debug.Log("shot");
        //instanite object
        //bring object back
        //give more power as project is hold down
    }
   
}

