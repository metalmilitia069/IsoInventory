using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _inventoryPanel;
    //[SerializeField]
    //private GameObject _playerReference;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("InventoryButtom"))
        {
            if(_inventoryPanel.activeSelf)
            {
                _inventoryPanel.SetActive(false);
            }
            else
            {
                _inventoryPanel.SetActive(true);
            }            
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    _playerReference.GetComponent<PlayerMove>().enabled = false;
    //    Debug.Log("mozvos desligados");
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    _playerReference.GetComponent<PlayerMove>().enabled = true;
    //}
}
