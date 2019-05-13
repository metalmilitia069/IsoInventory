using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _panel;
    //[SerializeField]
    //private Vector3 _mouseOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mousing over here");
        _panel.gameObject.SetActive(true);
        //_panel.transform.position = new Vector3(Input.mousePosition.x + _panel.gameObject;
        //_panel.transform.position = Input.mousePosition + _mouseOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse exited the slot");
        _panel.gameObject.SetActive(false);
    }


    //{
    //    
    //}
}
