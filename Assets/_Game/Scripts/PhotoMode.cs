using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PhotoMode : MonoBehaviour
{
    public Action OnPhotoTaken; //makes a varible hold a function

    [SerializeField] PhotoCapture photoCapture;
    [SerializeField] ShowRemovePhoto showRemovePhoto;
    [SerializeField] ScoreManager scoreManager;

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoom;

    public GameObject projectile;
    public Transform projectileSpawnPoint;

    public StarterAssets.ThirdPersonController player;

    public float forcehold = 0f;

    public bool isPhotoModeOn;

   
    // Update is called once per frame
    void Update()
    {
        HandlePhotoModeInput();

        HandlePhotoCaptureInput();

    }


    private void HandlePhotoCaptureInput()
    {
        if (Input.GetMouseButtonDown(0) && isPhotoModeOn)
        {
            //Debug.Log("Input to handler");
            scoreManager.getPhotoScore();
            HandleTakePhoto();       
            
        }
    }

    private void HandlePhotoModeInput()
    {
        if (Input.GetMouseButtonDown(1) && !isPhotoModeOn) //right click hold down zooms in
        {
            UiManager.singleton.ToggleCameraUi(true);
            player.SprintSpeed = 1;
            player.MoveSpeed = 1;
            zoom.Priority = 11;
            PhotoModeOn();
            //Debug.Log("zoom");
           
        }
        else if (Input.GetMouseButtonDown(1) && isPhotoModeOn) //right click release zooms out
        {
            UiManager.singleton.ToggleCameraUi(false);
            player.SprintSpeed = 5.335f;
            player.MoveSpeed = 2;
            zoom.Priority = 9;
            isPhotoModeOn = false;
            showRemovePhoto.RemovePhoto();
            //Debug.Log("ZOOM OFF");
        }
    }

    private void HandleTakePhoto()
    {      
            //Debug.Log("RUN SCRIPT TO TAKE PHOTO");
            photoCapture.TakeAPicture();
            if(OnPhotoTaken != null)
            OnPhotoTaken.Invoke();
            //showRemovePhoto.ShowPhoto();
    }

    private void PhotoModeOn()
    {
        isPhotoModeOn = true;
    }

}
