using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class UiFeels : MonoBehaviour
{

    public MMFeedbacks pictureReveals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PictureFeels()
    {
        pictureReveals?.PlayFeedbacks();
    }
}
