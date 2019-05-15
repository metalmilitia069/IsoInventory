using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class UIManager : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    [Header("Inventory UI Settings: ")]
    [SerializeField]
    private GameObject _inventoryPanel;
    [SerializeField]
    public GameObject itemInformationPanel;
    [SerializeField]
    public TextMeshProUGUI _itemName;
    [SerializeField]
    public TextMeshProUGUI _itemStatsText;
    [SerializeField]
    public TextMeshProUGUI _itemStatsTextNumbers;
    [SerializeField]
    public Image itemHold;
    [SerializeField]
    public int transitionItemIndex;
    //[HideInInspector]
    public InventorySlot inventorySlotTransition;
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

        if(itemHold.sprite != null)
        {
            UIManager.instance.itemHold.transform.position = Input.mousePosition;
        }
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
