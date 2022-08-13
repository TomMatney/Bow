using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ClickPhoto : MonoBehaviour
{
    public Button yourButton;
    public Button quitButton;


    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoomPicCamera;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btnQuit = quitButton.GetComponent<Button>();
        btnQuit.onClick.AddListener(EscClick);

    }
    void TaskOnClick()
    {
        quitButton.gameObject.SetActive(true);
        zoomPicCamera.Priority = 11;
        Debug.Log("You have clicked the button!");
    }

    void EscClick()
    {
        quitButton.gameObject.SetActive(false);
        zoomPicCamera.Priority = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
