using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRemovePhoto : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;

    

    private Texture2D screenCapture;

    public void ShowPhoto()
    { 
        photoFrame.SetActive(true);
    }

    public void RemovePhoto()
    {
        //Debug.Log("REMOVED");
        photoFrame.SetActive(false);
    }

  


    
}
