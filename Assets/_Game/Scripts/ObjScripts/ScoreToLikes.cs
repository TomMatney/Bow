using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreToLikes : MonoBehaviour
{
    [SerializeField] ClickPhoto clickPhoto;
    public int pictureLikes;
    public TextMeshProUGUI likesUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        likesUi.SetText(pictureLikes.ToString("Likes" + pictureLikes));

       
    }

    public void scoreToLikeDo()
    {
        if (clickPhoto.score == 0)
        {
            return;
        }



        pictureLikes = (int)(clickPhoto.score / 100 * 1.3);
        //100 sccore = 1 like
        //200 score = 2 likes
        //300 = 4
        //500 = 6
        //600 = 8
    }
}
