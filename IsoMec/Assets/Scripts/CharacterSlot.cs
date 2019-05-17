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


            //InventoryManager.instance.onInventoryChange();
            //this.hasEquipment = true;

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
            return;
        }
        //SWAP Item from Inventory to Equipment
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredEquipmentPiece != null)
        {
            //InventoryManager.instance.onInventoryChange();

            //this._slotIcon.sprite = UIManager.instance.itemHoldImage.sprite; //get sprite from transition item and put on current slot

            //UIManager.instance.itemHoldImage.sprite = this.itemStoredEquipmentPiece.itemIcon; //get sprite on current item reference and put on transition

            //CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(this.itemStoredEquipmentPiece); //remove current item reference from equipmentLIST
            //SwapVariables();
            ////CharacterEquipmentManager.instance.AddToCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //

            //InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);

            ////SwapVariables();
            //return;

            //CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition);
            ////Debug.Log("itemHoldObjectTransition = " + UIManager.instance.itemHoldObjectTransition.);
            ////SwapVariables();

            //this._slotIcon.sprite = this.itemStoredEquipmentPiece.itemIcon;
            //UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;

            //CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition);
            //CharacterEquipmentManager.instance.AddToCharacterEquipment(this.itemStoredEquipmentPiece);
            ////Debug.Log("itemHoldObjectTransition = " + UIManager.instance.itemHoldObjectTransition.name);
                        
            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //remove from equip list the item on previous slot OOOORRRR
            InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition); //remove from inventory list the item on previous slop

            SwapVariables();

            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //
            CharacterEquipmentManager.instance.AddToCharacterEquipment(this.itemStoredEquipmentPiece);

            UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;//this.itemStoredEquipmentPiece.itemIcon;
            this._slotIcon.sprite = this.itemStoredEquipmentPiece.itemIcon;

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

    
}
