using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjButtons : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    
    // Start is called before the first frame update
    void Start()
    {
       


        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            button1.enabled = true;
            //setColorCompletedCow();
            SetColorCompletedPig();
        }
    }

    

    public void SetColorCompletedCow()
    {
        button1.enabled = true;
        ColorBlock colors = button1.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        colors.selectedColor = new Color32(255, 100, 100, 255);
        colors.pressedColor = new Color32(255, 100, 100, 255);
        button1.colors = colors;
    }

    public void SetColorCompletedPig()
    {
        button2.enabled = true;
        ColorBlock colors = button2.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        colors.selectedColor = new Color32(255, 100, 100, 255);
        colors.pressedColor = new Color32(255, 100, 100, 255);
        button2.colors = colors;
    }

    public void SetColorCompletedDuck()
    {
        button3.enabled = true;
        ColorBlock colors = button3.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        colors.selectedColor = new Color32(255, 100, 100, 255);
        colors.pressedColor = new Color32(255, 100, 100, 255);
        button3.colors = colors;
    }
}
