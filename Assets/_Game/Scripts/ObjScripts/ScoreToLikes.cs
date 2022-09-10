using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreToLikes : MonoBehaviour
{
    
    public int pictureLikes;
    public TextMeshProUGUI likesUi;

    public ClickPhoto[] photos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calcLikes();
        likesUi.SetText("Likes:" + pictureLikes);

       
    }

    //evertime this parameter is called it gets the reference of score
    //when this functrion is called it takes click phtoot current state and uses its info
    public int scoreToLikeDo(ClickPhoto clickPhoto)
    {

        if (clickPhoto.score == 0)
        {
            return 0;
        }



        pictureLikes += (int)(clickPhoto.score / 100 * 1.2);
        print(clickPhoto.score);
        return pictureLikes;
        //100 sccore = 1 like
        //200 score = 2 likes
        //300 = 4
        //500 = 6
        //600 = 8
    }
    //go through all click photos and calc likes
    public void calcLikes()
    {
        int totalLikes = 0;
        foreach(ClickPhoto photo in photos)
        {
            totalLikes += scoreToLikeDo(photo);
        }
        pictureLikes = totalLikes;
    }
}
