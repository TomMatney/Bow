using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject scoreHold;

    [SerializeField] private GameObject cameraUI;
    public static UiManager singleton;
    //awalys there
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    public void ToggleCameraUi(bool state)
    {   //bool that controls camera on or off.
        cameraUI.SetActive(state);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
