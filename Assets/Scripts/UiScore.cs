using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScore : MonoBehaviour
{

    [SerializeField] PhotoMode photoMode;
    [SerializeField] ScoreManager scoreManager;

    public MMFeedbacks textNumberScore;

    private void updateScore()
    {
        Debug.Log("UpdateScore");
    }

    private void OnEnable()
    {
        photoMode.OnPhotoTaken += updateScore;
    }

    private void OnDisable()
    {
        photoMode.OnPhotoTaken -= updateScore;
    }

    public void ShowScoreText()
    {
        textNumberScore?.PlayFeedbacks();
    }

}
