using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class UIManager : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    #region Singleton

    private static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    [SerializeField]
    private GameObject _inventoryPanel;
    //[SerializeField]
    //private GameObject _inventorySpace;
    

    //[SerializeField]
    //private List<Button> _inventoryUIItems;

    //private int index;

    // Start is called before the first frame update
    void Start()
    {
        //foreach (Button item in _inventorySpace.GetComponentsInChildren<Button>())
        //{
        //    _inventoryUIItems.Add(item);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {        
        //foreach (Item item in InventoryManager.instance._inventoryList)
        //{
        //    GameObject butt = _inventoryUIItems[index].gameObject;
        //    butt.GetComponentInChildren<Transform>().GetComponent<Image>().sprite = item.itemIconPlaceHolder;            
        //}


        this.InventorySwitch();
    }

    private void InventorySwitch()
    {
        if (Input.GetButtonDown("InventoryButtom"))
        {
            if (_inventoryPanel.activeSelf)
            {
                _inventoryPanel.SetActive(false);
            }
            else
            {
                _inventoryPanel.SetActive(true);
            }
        }
    }

    
}
