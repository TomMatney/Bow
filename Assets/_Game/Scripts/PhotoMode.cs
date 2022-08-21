using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using MoreMountains.Feedbacks;

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

    [Header("FeelsSoundZoomInOut")]
    public MMFeedbacks feelsSoundZoomIn;
    public MMFeedbacks feelsSoundZoomOut;

    public float doubleCheckTime;

    // Update is called once per frame
    void Update()
    {
        HandlePhotoModeInput();

        HandlePhotoCaptureInput();

        if (!isPhotoModeOn)
        {
            UiManager.singleton.ToggleCameraUi(false);
        }

    }


    private void HandlePhotoCaptureInput()
    {
        if (Input.GetMouseButtonDown(0) && isPhotoModeOn)
        {
            if (photoCapture.viewingPhoto)
            {
                photoCapture.HidePhoto();
            }
            else
            {
                if (photoCapture.readyForPhoto == false)
                { return; }
                //Debug.Log("Input to handler");
                float score = scoreManager.getPhotoScore();
                HandleTakePhoto(score);
            }

                
        }
    }

    IEnumerator DoubleCheckUi()
    {
        if (!isPhotoModeOn)
        {
            yield return new WaitForSeconds(doubleCheckTime);
            UiManager.singleton.ToggleCameraUi(false);
        }
    }
    private void HandlePhotoModeInput()
    {
        if (Input.GetMouseButtonDown(1) && !isPhotoModeOn) //right click hold down zooms in
        {

            FeelsSoundZoomIn();
            UiManager.singleton.ToggleCameraUi(true);
            player.SprintSpeed = 1;
            player.MoveSpeed = 1;
            zoom.Priority = 11;
            PhotoModeOn();
            //Debug.Log("zoom");
           
        }
        else if (Input.GetMouseButtonDown(1) && isPhotoModeOn && photoCapture.showPhotoTimer <= 0) //right click release zooms out
        {
            photoCapture.HidePhoto();
            //StartCoroutine(DoubleCheckUi());
            FeelsSoundZoomOut();
            UiManager.singleton.ToggleCameraUi(false);
            player.SprintSpeed = 5.335f;
            player.MoveSpeed = 2;
            zoom.Priority = 9;
            isPhotoModeOn = false;
            showRemovePhoto.RemovePhoto();
            Debug.Log("ZOOM OFF");
        }
    }

    private void HandleTakePhoto(float score)
    {      
            //Debug.Log("RUN SCRIPT TO TAKE PHOTO");
            photoCapture.TakeAPicture(score);
            if(OnPhotoTaken != null)
            OnPhotoTaken.Invoke();
            //showRemovePhoto.ShowPhoto();
    }

    private void PhotoModeOn()
    {
        isPhotoModeOn = true;
    }

    public void FeelsSoundZoomIn()
    {
        feelsSoundZoomIn?.PlayFeedbacks();
    }

    public void FeelsSoundZoomOut()
    {
        feelsSoundZoomOut?.PlayFeedbacks();
    }
}
