using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ClickPhoto : MonoBehaviour
{
    [SerializeField] ScoreToLikes scoreToLikes;
    public Button yourButton;
    public Button quitButton;
    public Button scoreButton;

    public float score;

    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoomPicCamera;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        scoreButton.gameObject.SetActive(false);
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btnQuit = quitButton.GetComponent<Button>();
        btnQuit.onClick.AddListener(EscClick);

        Button btnScore = scoreButton.GetComponent<Button>();
        btnScore.onClick.AddListener(ScoreClick);

    }
    void TaskOnClick()
    {
        scoreButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        zoomPicCamera.Priority = 11;
        Debug.Log("You have clicked the button!");
    }

    void EscClick()
    {
        scoreButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        zoomPicCamera.Priority = 8;
        
    }

    void ScoreClick()
    {
        scoreToLikes.scoreToLikeDo();
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
