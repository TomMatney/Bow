using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using TMPro;

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

    [Header("DataBase")]
    [SerializeField] PhotoDatabase photoDatabase;

    [SerializeField] private float minShowPhotoTime = 1f;
    private float showPhotoTimer = 0f;

    [Header("Feels")]
    public MMFeedbacks feelsEnter;
    public MMFeedbacks feelsExit;
    public MMFeedbacks feelsStock;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private bool isCaptureingPhoto;
    private bool isHidingPhoto;

    public float exitTime;

    [Header("Stock")]
    public int pictureStock;
    public bool stockGone;
    public TextMeshProUGUI stockUi;


    private void Start()
    {
        screenCapture = new Texture2D(Screen.height, Screen.height, TextureFormat.RGB24, false);
        stockGone = true;
    }

    public void StockFeels()
    {
        pictureStock -= 1;
        FeelsStock();
    }

    public void TakeAPicture()
    {
       
        if (isHidingPhoto) 
        {
            return;
        }
        if (!viewingPhoto && stockGone)
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
        stockUi.SetText(pictureStock.ToString()); //= GetComponent<TextMeshProUGUI>();

        if (showPhotoTimer > 0f)
        {
            showPhotoTimer -= Time.deltaTime;
        }

        if(pictureStock == 0)
        {
            stockGone = false;
            Debug.Log("stock Gone");
        }
        else if(pictureStock > 0)
        {
            stockGone = true;
        }
    }



    IEnumerator CapturePhoto()
    {//alt enter
        viewingPhoto = true;
        cameraUI.SetActive(false);
        isCaptureingPhoto = true;
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        float height = Screen.height;
        float width = Screen.height;
        float x = Screen.width / 2f - width / 2f;
        Rect regionToRead = new Rect(x, 0, width, height);
        StockFeels(); //make this a function to add feels
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        TakePhotoData();
        if (isCaptureingPhoto) yield break; //cantspam
        //scoreManager.getPhotoScore();//reference for scoring photo
    }

    public void TakePhotoData()
    {
        float height = Screen.height;
        float width = Screen.height;
        float x = Screen.width / 2f - width / 2f;
        Rect regionToRead = new Rect(x, 0, width, height);

        Texture2D texture = new Texture2D((int)width, (int)height);
        texture.ReadPixels(regionToRead, 0, 0, false);
        texture.Apply();
        Sprite photoSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);

        StartCoroutine(CameraFlashEffect());
        fadingAnimation.Play("CameraAphla");

        PhotoDatabase.PhotoData photoData = new PhotoDatabase.PhotoData(); //pasing this object into the function
        photoData.texture = photoSprite;
        photoDatabase.AddPhoto(photoData);
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

    public void FeelsStock()
    {
        feelsStock?.PlayFeedbacks();
    }
}
