using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private bool isCaptureingPhoto;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    public void TakeAPicture()
    {   
        if (!viewingPhoto)
        {
            StartCoroutine(CapturePhoto());
        }
        else
        {
            RemovePhoto();
        }
    }

  
    IEnumerator CapturePhoto()
    {//alt enter
        viewingPhoto = true;
        if (isCaptureingPhoto) yield break; //cantspam
        cameraUI.SetActive(false);
        isCaptureingPhoto = true;
        viewingPhoto = true; 

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        TakePhotoData(); 
        scoreManager.getPhotoScore();//reference for scoring photo
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

    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        UiManager.singleton.ToggleCameraUi(true);
    }
}
