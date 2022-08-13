using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager: MonoBehaviour
{
    public Texture2D cursorTexture;
    public Texture2D startCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.SetCursor(startCursor, hotSpot, cursorMode);
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
        Cursor.visible = false;
    }

    public void showCursor()
    {
        Cursor.visible = true;
    }
}
