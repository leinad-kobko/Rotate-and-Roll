using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnMouseHover : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void OnMouseOver() 
    {
        if (button.interactable)
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
