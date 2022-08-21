using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Feedbacks;

public class GiveScoreForCompleteObjetive : MonoBehaviour
{
    public int objScore;
    public TextMeshProUGUI scoreUi;

    public MMFeedbacks feelsScoreObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreUi.SetText(objScore.ToString("Score:" + objScore));

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(objScore);
            AddScore();
        }
    }

    public void AddScore()
    {
        objScore += 1;
        FeelsScoreObj();
    }

    public void FeelsScoreObj()
    {
        feelsScoreObj?.PlayFeedbacks();
    }


}
