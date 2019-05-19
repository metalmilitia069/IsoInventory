using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [SerializeField]
    public Image _slotIcon;
    [SerializeField]
    public int _slotIndex;
    [SerializeField]
    private ItemPieceTypeSlot itemSlotType;
    [SerializeField]
    public Item itemStoredEquipmentPiece;
    [SerializeField]
    public bool hasEquipment = false;

    private Image _temporaryIcon;

    public enum ItemPieceTypeSlot
    {
        Helmet,
        Chest,
        Belt,
        Pants,
        Boots,
        Weapon,
        Shield,
        Earings,
        Necklace,
        Rings,
        None
    }
    // Start is called before the first frame update
    void Start()
    {
        _temporaryIcon = this.gameObject.AddComponent<Image>();
        //_temporaryIcon.gameObject.SetActive(false);
        _temporaryIcon.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceItem()
    {
        //PLACE Item in Equipment from Inventory
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredEquipmentPiece == null)
        {
            UIManager.instance.itemHoldImage.sprite = null;
            UIManager.instance.itemHoldImage.gameObject.SetActive(false);

            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition);

            this.itemStoredEquipmentPiece = UIManager.instance.itemHoldObjectTransition;
            UIManager.instance.itemHoldObjectTransition = null;

            this._slotIcon.sprite = this.itemStoredEquipmentPiece.itemIcon;
            this._slotIcon.color = Color.white;

            this.hasEquipment = true;

            CharacterEquipmentManager.instance.AddToCharacterEquipment(this.itemStoredEquipmentPiece);
            InventoryManager.instance.RemoveFromInventory(this.itemStoredEquipmentPiece);

            InventoryManager.instance.onInventoryUpdate(); ///////////
            InventoryManager.instance.onEquipmentChange();

            //UIManager.instance.isOnTransition = false;

            return;
        }
        //GRAB Item from Equipment
        if (UIManager.instance.itemHoldImage.sprite == null && this.itemStoredEquipmentPiece != null)
        {
            UIManager.instance.itemHoldImage.sprite = this.itemStoredEquipmentPiece.itemIcon;
            UIManager.instance.itemHoldImage.gameObject.SetActive(true);

            UIManager.instance.itemHoldObjectTransition = this.itemStoredEquipmentPiece;

            this._slotIcon.color = Color.gray;

            this.hasEquipment = false;

            UIManager.instance.isOnTransition = true;

            return;
        }
        //SWAP Item from Inventory to Equipment
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredEquipmentPiece != null)
        {
            if (this.itemStoredEquipmentPiece == UIManager.instance.itemHoldObjectTransition)
            {
                CancelAction();

                return;
            }

            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //remove from equip list the item on previous slot OOOORRRR
            InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition); //remove from inventory list the item on previous slop

            SwapVariables();

            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //
            CharacterEquipmentManager.instance.AddToCharacterEquipment(this.itemStoredEquipmentPiece);

            UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;//this.itemStoredEquipmentPiece.itemIcon;
            this._slotIcon.sprite = this.itemStoredEquipmentPiece.itemIcon;


            InventoryManager.instance.onInventoryUpdate();////////////////////////
            InventoryManager.instance.onEquipmentChange();

            UIManager.instance.isOnTransition = true;

            return;
        }        
    }

    public void SwapVariables()
    {
        Item item;
        item = UIManager.instance.itemHoldObjectTransition;
        UIManager.instance.itemHoldObjectTransition = this.itemStoredEquipmentPiece;
        this.itemStoredEquipmentPiece = item;
        item = null;        
    }

    public void CancelAction()
    {
        UIManager.instance.itemHoldImage.sprite = null;
        UIManager.instance.itemHoldImage.gameObject.SetActive(false);

        UIManager.instance.itemHoldObjectTransition = null;

        this.hasEquipment = true;

        this._slotIcon.color = Color.white;
        Debug.Log("aiaiaiaiaaiaiiaiaaiiaiaiaia");        
    }

    
}
