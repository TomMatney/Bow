using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour
{
    [SerializeField] PhotoCapture photoCapture;
    [SerializeField] PhotoMode photoMode;
    [SerializeField] ScoreManager scoreManager;

    public MMFeedbacks textNumberScore;
    public TextMeshProUGUI scoreHolder;

    private void updateScore()
    {
        scoreHolder.SetText(scoreManager.lastScore.ToString());
        ShowScoreText();
        Debug.Log("Something Happening");
    }

    private void OnEnable()
    {
        Debug.Log("has enabled");
       photoMode.OnPhotoTaken += updateScore;
    }

    private void OnDisable()
    {
        Debug.Log("has disabled");
        photoMode.OnPhotoTaken -= updateScore;
    }

    public void ShowScoreText()
    {
        textNumberScore?.PlayFeedbacks();
    }

}
