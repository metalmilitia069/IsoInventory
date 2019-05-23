using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlotsBase : MonoBehaviour
{
    [Header("Item Name Floating Text")]
    //[Multiline(8)]
    [SerializeField]
    public string itemName = "";
    [SerializeField]
    public TextMeshPro itemNameFloatText;
    //[SerializeField]
    //private float itemNameHeight = 2f;
    [Header("Item Attributes")]
    [SerializeField]
    public int attackDamage;
    [SerializeField]
    public int attackRange;
    [SerializeField]
    public int criticalChance;
    [SerializeField]
    public string elementalDamage;
    [Header("Image Reference")]
    [SerializeField]
    public Image itemIcon;
    [SerializeField]
    public string itemCategory = "";
    [SerializeField]
    public string itemPieceType = "";

    [Header("Information Panels")]
    //[SerializeField]
    //private GameObject _itemInformationPanel;
    [SerializeField]
    public TextMeshProUGUI itemNameText;
    [SerializeField]
    public TextMeshProUGUI itemStatsText;
    [SerializeField]
    public TextMeshProUGUI itemStatsNumbersText;
    [Header("Stored Item")]
    [SerializeField]
    public Item storedItem;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.onItemPickup += OnItemPickup;
        //EventManager.instance.onItemRemoved += OnItemRemoved;
        SetInformationPanelReference();
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemPickup()
    {
        if (this.storedItem != null)
        {
            this.itemName = this.storedItem.itemName;
            this.itemNameFloatText = this.storedItem.itemNameFloatText;
            this.attackDamage = this.storedItem.attackDamage;
            this.criticalChance = this.storedItem.criticalChance;
            this.elementalDamage = this.storedItem.elementalDamage;
            this.itemIcon.sprite = this.storedItem.itemIcon;
            this.itemIcon.color = Color.white;
            this.itemCategory = this.storedItem.itemCategory.ToString();
            this.itemPieceType = this.storedItem.itemPieceType.ToString();
        }
    }

    //public void OnItemRemoved()//(InventorySlot inventorySlot)
    //{
    //    if (this.storedItem == null)
    //    {
    //        this.itemName = null;
    //        this.itemNameFloatText = null;
    //        this.attackDamage = 0;
    //        this.criticalChance = 0;
    //        this.elementalDamage = null;
    //        this.itemIcon.sprite = null;
    //        this.itemIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);
    //        this.itemCategory = "";
    //        this.itemPieceType = "";
    //    }
    //}

    private void SetInformationPanelReference()
    {        
        this.itemNameText = UIManager.instance.itemNameText;
        this.itemStatsText = UIManager.instance.itemStatsText;
        this.itemStatsNumbersText = UIManager.instance.itemStatsNumbersText;
    }

    public void ShowItemStats()
    {
        UIManager.instance.itemInformationPanel.gameObject.SetActive(true);
        this.itemNameText.text = this.itemName;
        this.itemNameText.color = this.itemNameFloatText.color;
        this.itemStatsText.text = "Attack Damage: \n" + "Attack Range: \n" + "Critical Chance: \n" + "Elemental Damage: ";
        this.itemStatsNumbersText.text = this.attackDamage.ToString() + "\n" + this.attackRange.ToString() + "\n" + this.criticalChance.ToString() + "\n" + this.elementalDamage;
    }

    public void HideItemStats()
    {
        UIManager.instance.itemInformationPanel.gameObject.SetActive(false);
        this.itemNameText.text = null;
        this.itemStatsText.text = null;
        this.itemStatsNumbersText.text = null; 
    }

    public void TransferItem()
    {
        //Grab Item
        if (this.storedItem != null && InventoryManager.instance.ItemTransfer == null)
        {
            //this.storedItem.wasPicked = true;
            InventoryManager.instance.ItemTransfer = this.storedItem;
            this.itemIcon.color = Color.gray;
            UIManager.instance.itemFloatingIcon.sprite = InventoryManager.instance.ItemTransfer.itemIcon;
            UIManager.instance.itemFloatingIcon.gameObject.SetActive(true);
            //UIManager.instance.RemoveFromInventorySlot(this);////to fix
            UIManager.instance.uiSlotReference = this;
            return;
        }
        //Putting Item
        if (this.storedItem != null && InventoryManager.instance.ItemTransfer != null)
        {
            //Putting Item Back on Previous Slot (AKA Canceling Action)
            if (InventoryManager.instance.ItemTransfer == this.storedItem)
            {
                Debug.Log("eita mah");
                InventoryManager.instance.ItemTransfer.wasPicked = false;
                this.storedItem = InventoryManager.instance.ItemTransfer;
                InventoryManager.instance.ItemTransfer = null;
                this.itemIcon.color = Color.white;
                UIManager.instance.itemFloatingIcon.sprite = null;
                UIManager.instance.itemFloatingIcon.gameObject.SetActive(false);
                return;
            }
            //Switch Items
            else
            {
                UIManager.instance.RemoveFromInventorySlot(UIManager.instance.uiSlotReference);
                InventoryManager.instance.RemoveFromInventory(InventoryManager.instance.ItemTransfer);
                InventoryManager.instance.RemoveFromInventory(this.storedItem);
                Item item = InventoryManager.instance.ItemTransfer;                
                InventoryManager.instance.ItemTransfer = this.storedItem;
                UIManager.instance.RemoveFromInventorySlot(this);

                UIManager.instance.AddToInventorySlotOnTransfer(this, item);                
                InventoryManager.instance.AddToInventory(item);
                item = null;
                
                UIManager.instance.itemFloatingIcon.sprite = InventoryManager.instance.ItemTransfer.itemIcon;
                UIManager.instance.itemFloatingIcon.gameObject.SetActive(true);
               // InventoryManager.instance.ItemTransfer.wasPicked = true;
               // this.storedItem.wasPicked = false;
                UIManager.instance.OnItemRemoved();
                return;
            }
        }
        if (this.storedItem == null && InventoryManager.instance.ItemTransfer != null)
        {
            this.storedItem = InventoryManager.instance.ItemTransfer;
            UIManager.instance.itemFloatingIcon.sprite = null;
            UIManager.instance.itemFloatingIcon.gameObject.SetActive(false);
            InventoryManager.instance.ItemTransfer = null;
            UIManager.instance.AddToInventorySlotOnTransfer(this, this.storedItem);
            InventoryManager.instance.AddToInventory(this.storedItem);
            EventManager.instance.onItemPickup();



        }
        //Debug.Log("mozovos");
        
    }
}
