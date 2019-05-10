using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Sprite itemIconPlaceHolder;
    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        Debug.Log("This Is An Item!");

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicking on Item");
        }

    }
}
