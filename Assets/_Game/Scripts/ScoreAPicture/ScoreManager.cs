using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
   [SerializeField] PictureTarget pictureTarget;
   public float lastScore;
    
    public List<PictureTarget> GetTargetsInFrame()
    {
        List<PictureTarget> inFrame = new List<PictureTarget>();

        PictureTarget[] targets = FindObjectsOfType<PictureTarget>();
        //take a picture of cow, targets has cow in it
        foreach (PictureTarget target in targets)
        {
            foreach (Renderer rend in target.GetComponentsInChildren<Renderer>())
            {
                if (rend.isVisible)
                {
                    if (Vector3.Distance(Camera.main.transform.position, target.transform.position) > 20)
                    {
                        continue;
                    }

                    
                    //set picture types here
                    if (target.objectiveType == ObjectiveTypes.Cow)
                    {           
                        //target is a 
                       
                        target.CowCapture();
                    }

                    if(target.objectiveType == ObjectiveTypes.Pig)
                    {
                        target.PigCapture();
                    }

                    if(target.objectiveType == ObjectiveTypes.Duck)
                    {
                        target.DuckCapture();
                    }


                    inFrame.Add(target);
                    break;
                }
            }
        }

        return inFrame;
    }

    //.5 if on edge, 0 if in center
    public float GetIsCenterOfFrame(Vector3 position)
    {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(position);
        Vector2 middleOfScreen = new Vector2(0.5f, 0.5f);

        return 1f - Vector2.Distance(screenPos, middleOfScreen) * 2f;
    }
    float DistanceToTargetScore(float targetDistance)
    {
        float score = 0f;
        float minDistance = 0f;
        float maxDistance = 100f;
        float perfectDistance = 7f;
        if (targetDistance >= perfectDistance)
        {
            score = Mathf.InverseLerp(maxDistance, perfectDistance, targetDistance);
        }
        else
        {
            score = Mathf.InverseLerp(minDistance, perfectDistance, targetDistance);
        }
        return score;
    }
    public float getPhotoScore()
    {
        float score = 0f;
        List<PictureTarget> targets = GetTargetsInFrame();
        //Debug.Log("# on screen " + targets.Count);
        foreach (PictureTarget target in targets)
        {   //1= center 0 is edge
            float centerFrame = GetIsCenterOfFrame(target.transform.position);
            float distance = Vector3.Distance(Camera.main.transform.position, target.transform.position);
            float distanceFrame = DistanceToTargetScore(distance);

            //score += 500f * centerFrame;
            score += centerFrame * 250f;
            score += distanceFrame * 250f;
            //Debug.Log("Frame " + GetIsCenterOfFrame(target.transform.position));
            //Debug.Log("Distance " + Vector3.Distance(Camera.main.transform.position, target.transform.position));

            Debug.Log(score);
        }
        lastScore = score;
        return score;


    }
   

}