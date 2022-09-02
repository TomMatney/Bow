using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class AttachPicture : MonoBehaviour
{
    [SerializeField] LineRenderer lineRender;
    [SerializeField] Restocker restock;
    public int lineIndex;

    [SerializeField] bool movePhotoOut = true;

    public MMFeedbacks animationPicture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void lineIndexNull()
    {
        if(restock.inOut)
        {
            movePhotoOut = false;
            attachPicMove();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movePhotoOut)
        {
            Vector3 postion = lineRender.GetPosition(lineIndex);
            transform.position = postion;
        }
    }

    public void attachPicMove()
    {
        animationPicture?.PlayFeedbacks();
    }
}
