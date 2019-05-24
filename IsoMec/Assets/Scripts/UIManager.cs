using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [SerializeField]
    private GameObject _inventoryPanel;


    [SerializeField]
    public ItemFloatingImage itemFloatingImageGO;
    //[SerializeField]
    //public Image itemTransferImage;


    [SerializeField]
    public GameObject itemInformationPanel;
    [SerializeField]
    public TextMeshProUGUI itemNameText;
    [SerializeField]
    public TextMeshProUGUI itemStatsText;
    [SerializeField]
    public TextMeshProUGUI itemStatsNumbersText;


    [SerializeField]
    public UISlotsBase uiSlotReference;


    [SerializeField]
    public GameObject inventorySpace;

    public List<InventorySlot> listOfinventorySlots;

    private void Update()
    {
        OpenInventoryPanel();
        //_inventoryPanel == null ? _inventoryPanel.gameObject.SetActive(true) : _inventoryPanel.gameObject.SetActive(false);
    }

    private void OpenInventoryPanel()
    {
        if (Input.GetButtonDown("InventoryButton"))
        {
            if (!this._inventoryPanel.activeSelf)
            {
                this._inventoryPanel.gameObject.SetActive(true);
            }
            else
            {
                this._inventoryPanel.gameObject.SetActive(false);
            }
        }
    }
        
    private void Start()
    {
        //listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());

        listOfinventorySlots.AddRange(inventorySpace.GetComponentsInChildren<InventorySlot>());

        //EventManager.instance.onAddToInventory += AddToInventorySlot;
    }

    public void AddToInventorySlotOnPickup(Item item)
    {
        for (int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            if (listOfinventorySlots[i].storedItem == null)
            {
                listOfinventorySlots[i].storedItem = item;
                break;
            }
            
        }
    }

    public void AddToInventorySlotOnTransfer(UISlotsBase uISlotsBase, Item item)
    {
        uISlotsBase.storedItem = item;
        EventManager.instance.onItemPickup();
    }

    //public void AddToCharacterSlotOnTransfer(CharacterSlot uICharacterSlot, Item item)
    //{
    //    uICharacterSlot.storedItem = item;
    //    EventManager.instance.onItemPickup();
    //}
        


    public void RemoveFromInventorySlot(UISlotsBase uISlotsBase)
    {
        uISlotsBase.storedItem = null;
    }

    public void OnGrabbingItem()
    {
        
        this.itemFloatingImageGO.hasBeenEnabled = true;
        this.itemFloatingImageGO.gameObject.SetActive(true);
    }

    public void OnPuttingItem()
    {
        this.itemFloatingImageGO.hasBeenEnabled = false;
    }

    public void OnItemRemoved()
    {
        for (int i = 0; i < this.listOfinventorySlots.Count; i++)//(int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            if (listOfinventorySlots[i].storedItem == null)
            {
                //listOfinventorySlots[i].storedItem = null;
                listOfinventorySlots[i].itemName = null;
                listOfinventorySlots[i].itemNameFloatText = null;
                listOfinventorySlots[i].attackDamage = 0;
                listOfinventorySlots[i].criticalChance = 0;
                listOfinventorySlots[i].elementalDamage = null;
                listOfinventorySlots[i].itemIcon.sprite = null;
                listOfinventorySlots[i].itemIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);
                listOfinventorySlots[i].itemCategory = "";
                listOfinventorySlots[i].itemPieceType = "";
                //this.itemName = null;
                //this.itemNameFloatText = null;
                //this.attackDamage = 0;
                //this.criticalChance = 0;
                //this.elementalDamage = null;
                //this.itemIcon.sprite = null;
                //this.itemIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);
                //this.itemCategory = "";
                //this.itemPieceType = "";
            }

        }
    }
}
