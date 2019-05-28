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
        if (this.storedItem != null && InventoryManager.instance.ItemTransfer == null)
        {            
            this.itemIcon.color = Color.gray;
            InventoryManager.instance.ItemTransfer = this.storedItem;
            UIManager.instance.uiSlotReference = this;
            UIManager.instance.OnGrabbingItem();
            return;
        }
        if (this.storedItem != null && InventoryManager.instance.ItemTransfer != null)
        {
            //putting back an item
            if (this == UIManager.instance.uiSlotReference)
            {
                this.itemIcon.color = Color.white;
                InventoryManager.instance.ItemTransfer = null;
                UIManager.instance.uiSlotReference = null;
                UIManager.instance.OnPuttingItem();
                return;
            }
            //swap items
            if (this != UIManager.instance.uiSlotReference)
            {
                InventoryManager.instance.RemoveFromInventory(UIManager.instance.uiSlotReference.storedItem);
                CharacterEquipmentManager.instance.RemoveFromEquipmentList(UIManager.instance.uiSlotReference.storedItem);
                Item item = InventoryManager.instance.ItemTransfer;
                InventoryManager.instance.ItemTransfer = this.storedItem;
                InventoryManager.instance.RemoveFromInventory(this.storedItem);
                InventoryManager.instance.RemoveFromInventory(UIManager.instance.uiSlotReference.storedItem);
                CharacterEquipmentManager.instance.RemoveFromEquipmentList(this.storedItem);
                CharacterEquipmentManager.instance.RemoveFromEquipmentList(UIManager.instance.uiSlotReference.storedItem);
                UIManager.instance.RemoveFromInventorySlot(UIManager.instance.uiSlotReference);
                UIManager.instance.OnItemRemoved();
                CharacterEquipmentManager.instance.OnItemRemovedFromCharacterEquipment();
                UIManager.instance.AddToInventorySlotOnTransfer(this, item);
                if (this is CharacterSlot)
                {
                    CharacterEquipmentManager.instance.AddToCharacterEquipmentList(item);//
                }
                else if (this is InventorySlot)
                {
                    InventoryManager.instance.AddToInventory(item);//
                }                
                UIManager.instance.OnGrabbingItem();
                return;
            }
        }
        //putting on empty slot
        if (this.storedItem == null && InventoryManager.instance.ItemTransfer != null)
        {
            InventoryManager.instance.RemoveFromInventory(InventoryManager.instance.ItemTransfer);
            CharacterEquipmentManager.instance.RemoveFromEquipmentList(InventoryManager.instance.ItemTransfer);
            UIManager.instance.RemoveFromInventorySlot(UIManager.instance.uiSlotReference);
            UIManager.instance.OnItemRemoved();
            CharacterEquipmentManager.instance.OnItemRemovedFromCharacterEquipment();
            UIManager.instance.AddToInventorySlotOnTransfer(this, InventoryManager.instance.ItemTransfer);            
            InventoryManager.instance.ItemTransfer = null;
            if (this is InventorySlot)
            {
                InventoryManager.instance.AddToInventory(this.storedItem);
            }
            else if(this is CharacterSlot)
            {
                CharacterEquipmentManager.instance.AddToCharacterEquipmentList(this.storedItem);
            }            
            UIManager.instance.OnItemRemoved();
            UIManager.instance.OnPuttingItem();
            return;            
        }
    }
}
