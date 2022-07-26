using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Audio")]
    [SerializeField] private AudioSource cameraAudio;

    [SerializeField] ShowRemovePhoto removePhoto;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] private float minShowPhotoTime = 1f;
    private float showPhotoTimer = 0f;

    public MMFeedbacks feelsEnter;
    public MMFeedbacks feelsExit;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private bool isCaptureingPhoto;
    private bool isHidingPhoto;

    public float exitTime;


    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    public void TakeAPicture()
    {
        if (isHidingPhoto) 
        {
            return;
        }
        if (!viewingPhoto)
        {
            FeelsEnterRun();
            StartCoroutine(CapturePhoto());
            showPhotoTimer = minShowPhotoTime;
        }
        else
        {
            if (showPhotoTimer <= 0f)
            {
                RemovePhoto();
            }
        }
    }

    private void Update()
    {
        if(showPhotoTimer > 0f)
        {
            showPhotoTimer -= Time.deltaTime;
        }
    }



    IEnumerator CapturePhoto()
    {//alt enter
        viewingPhoto = true;
        cameraUI.SetActive(false);
        isCaptureingPhoto = true;
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        TakePhotoData();
        if (isCaptureingPhoto) yield break; //cantspam
        //scoreManager.getPhotoScore();//reference for scoring photo
    }

    public void TakePhotoData()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);

        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("CameraAphla");
    }

    IEnumerator CameraFlashEffect()
    {
        cameraAudio.Play();
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
        isCaptureingPhoto = false;
    }

    IEnumerator PlayThenRemove()
    {
        isHidingPhoto = true;
        FeelsExitRun();
        yield return new WaitForSeconds(exitTime);
        viewingPhoto = false;
        photoFrame.SetActive(false);
        UiManager.singleton.ToggleCameraUi(true);
        isHidingPhoto = false;
    }

    void RemovePhoto()
    {
        StartCoroutine(PlayThenRemove());
    }

    public void FeelsEnterRun()
    {
        feelsEnter?.PlayFeedbacks();
    }

    public void FeelsExitRun()
    {
        feelsExit?.PlayFeedbacks();
    }
}
