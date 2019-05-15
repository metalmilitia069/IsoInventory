using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    #region Singleton
    public static MouseManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //public Sprite itemHold;
    public Texture2D itemHold;
    //public Texture2D itemHold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(itemHold != null)
        {
            //Cursor.SetCursor(itemHold, new Vector2(50, 50), CursorMode.Auto);
            //Cursor.SetCursor(itemHold, Vector2.zero, CursorMode.Auto);
            //Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    public void HoldItem()
    {
        //Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
        //Cursor.SetCursor()
    }

    
}
