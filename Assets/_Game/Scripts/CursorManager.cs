using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager: MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D startCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private int unlockedCounter = 0;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // hideCursor();
        yield return null;
        SetCameraLock(true);

        //Cursor.SetCursor(startCursor, hotSpot, cursorMode);
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 cursosPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = cursosPos;
    }

    //void OnMouseEnter()
    //{
    //    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}

    public void hideCursor()
    {
        SetCameraLock(true);
        //Cursor.visible = false;
    }

    public void showCursor()
    {
        SetCameraLock(false);
        //Cursor.visible = true;
    }

    public void SetCameraLock(bool locked)
    {
        if (locked)
        {
            unlockedCounter++;
        }
        else
        {
            unlockedCounter--;
        }
        bool shouldLock = unlockedCounter == 0;
        Cursor.lockState = shouldLock ? CursorLockMode.Locked : CursorLockMode.None;
    }

    private void OnApplicationFocus(bool focus)
    {
        bool shouldLock = unlockedCounter == 0;
        Cursor.lockState = shouldLock ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
