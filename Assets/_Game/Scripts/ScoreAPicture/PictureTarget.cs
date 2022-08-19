using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureTarget : MonoBehaviour
{
    [SerializeField] public ObjectiveTypes objectiveType;
    [SerializeField] ObjButtons objButtons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CowCapture()
    {
        //how to distance different animals 
        //how to score different animals
        //center points and stlish
        objButtons.SetColorCompletedCow();
        Debug.Log("THIS HAS BEEN CAPTURE");
    }

    public void PigCapture()
    {
        objButtons.SetColorCompletedPig();
    }

    public void DuckCapture()
    {
        objButtons.SetColorCompletedDuck();
    }
}
