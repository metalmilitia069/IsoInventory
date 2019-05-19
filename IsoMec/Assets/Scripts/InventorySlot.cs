using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{    
    [SerializeField]
    public Image _slotIcon;
    [SerializeField]
    public int _slotIndex;
    [SerializeField]
    public Item itemStoredInventorySlot;


    private bool isLocked = false;
    public bool hasEquipment = false;

    private void Start()
    {
        //InventoryManager.instance.onInventoryChange += UpdateItemInventorySlot;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("mousing over here");

        //if (this.hasEquipment == true) // < InventoryManager.instance._inventoryList.Count)
        //{
        //    UIManager.instance.itemInformationPanel.gameObject.SetActive(true);
            
        //    UIManager.instance._itemName.text = InventoryManager.instance._inventoryList[this._slotIndex]._itemName;
        //    UIManager.instance._itemName.color = InventoryManager.instance._inventoryList[this._slotIndex]._itemNameFloatText.color;
        //    UIManager.instance._itemStatsText.text = "Attack Damage: " + "\n" + "Attack Range: " + "\n" + "Critical Chance: " + "\n" + "Elemental Damage: ";
        //    UIManager.instance._itemStatsTextNumbers.text = InventoryManager.instance._inventoryList[this._slotIndex].attackDamage.ToString() + "\n"
        //        + InventoryManager.instance._inventoryList[this._slotIndex].attackRange.ToString() + "\n"
        //        + InventoryManager.instance._inventoryList[this._slotIndex].criticalChance.ToString() + "\n"
        //        + InventoryManager.instance._inventoryList[this._slotIndex].elementalDamage;

        //    //UIManager.instance._
        //}

        if (this.hasEquipment == true) // < InventoryManager.instance._inventoryList.Count)
        {
            UIManager.instance.itemInformationPanel.gameObject.SetActive(true);

            UIManager.instance._itemName.text = this.itemStoredInventorySlot._itemName;
            UIManager.instance._itemName.color = this.itemStoredInventorySlot._itemNameFloatText.color;
            UIManager.instance._itemStatsText.text = "Attack Damage: " + "\n" + "Attack Range: " + "\n" + "Critical Chance: " + "\n" + "Elemental Damage: ";
            UIManager.instance._itemStatsTextNumbers.text = this.itemStoredInventorySlot.attackDamage.ToString() + "\n"
                + this.itemStoredInventorySlot.attackRange.ToString() + "\n"
                + this.itemStoredInventorySlot.criticalChance.ToString() + "\n"
                + this.itemStoredInventorySlot.elementalDamage;

            //UIManager.instance._
        }
        //_panel.transform.position = new Vector3(Input.mousePosition.x + _panel.gameObject;
        //_panel.transform.position = Input.mousePosition + _mouseOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse exited the slot");
        if (this._slotIndex < InventoryManager.instance._inventoryList.Count)
        {
            UIManager.instance.itemInformationPanel.gameObject.SetActive(false);
        }
    }

    public void TransferItem()
    {
        //GRAB Item From Inventory
        if (UIManager.instance.itemHoldImage.sprite == null && this.itemStoredInventorySlot != null)
        {
            UIManager.instance.itemHoldImage.sprite = this.itemStoredInventorySlot.itemIcon;
            UIManager.instance.itemHoldImage.gameObject.SetActive(true);

            UIManager.instance.itemHoldObjectTransition = this.itemStoredInventorySlot;

            this._slotIcon.color = Color.gray;

            //this.isLocked = true;
            this.hasEquipment = false;
            

            return;
        }
        //PLACE Item in Inventory From Equipment
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredInventorySlot == null)
        {

            //if (isLocked)
            //{
                InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);

                UIManager.instance.itemHoldImage.sprite = null;
                UIManager.instance.itemHoldImage.gameObject.SetActive(false);

                this.itemStoredInventorySlot = UIManager.instance.itemHoldObjectTransition;
                UIManager.instance.itemHoldObjectTransition = null;

                this._slotIcon.sprite = this.itemStoredInventorySlot.itemIcon;
                this._slotIcon.color = Color.white;

                InventoryManager.instance.AddToInventory(this.itemStoredInventorySlot);
                CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(this.itemStoredInventorySlot);

                this.hasEquipment = true;


               InventoryManager.instance.onInventoryUpdate();
               InventoryManager.instance.onEquipmentChange();

               //UIManager.instance.isOnTransition = false;
            //}

            return;
        }
        //SWAP Items
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredInventorySlot != null)
        {
            //this.isLocked = true;

            if (this.itemStoredInventorySlot == UIManager.instance.itemHoldObjectTransition)
            {
                CancelAction();

                return;
            }

            ///NEW
            //InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);
            if (isLocked || UIManager.instance.isOnTransition)
            {
                CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //se o inv so tiver um item, ele vai ser deletado no processo de troca << ajeitar isso!!!
                isLocked = false;
            }
            InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);
            SwapVariables();
            InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);
            InventoryManager.instance.AddToInventory(this.itemStoredInventorySlot);
            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition);

            UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;
            this._slotIcon.sprite = this.itemStoredInventorySlot.itemIcon;


            InventoryManager.instance.onInventoryUpdate();
            InventoryManager.instance.onEquipmentChange();

            UIManager.instance.isOnTransition = false;
            this.hasEquipment = true;
            //SwapVariables();



            //CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //remove from equip list the item on previous slot OOOORRRR
            //InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition); //remove from inventory list the item on previous slop


            //SwapVariables();

            ////CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition);
            //InventoryManager.instance.AddToInventory(this.itemStoredInventorySlot);
            //InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);



            //UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;//this.itemStoredEquipmentPiece.itemIcon;

            return;
        }

        //    if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredEquipmentPiece != null)
        //    {
        //        if (this.itemStoredEquipmentPiece == UIManager.instance.itemHoldObjectTransition)
        //        {
        //            CancelAction();

        //            return;
        //        }

        //        CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //remove from equip list the item on previous slot OOOORRRR
        //        InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition); //remove from inventory list the item on previous slop

        //        SwapVariables();

        //        CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(UIManager.instance.itemHoldObjectTransition); //
        //        CharacterEquipmentManager.instance.AddToCharacterEquipment(this.itemStoredEquipmentPiece);

        //        UIManager.instance.itemHoldImage.sprite = UIManager.instance.itemHoldObjectTransition.itemIcon;//this.itemStoredEquipmentPiece.itemIcon;
        //        this._slotIcon.sprite = this.itemStoredEquipmentPiece.itemIcon;

        //        return;
        //    }
        //}        
    }

    public void SwapVariables()
    {
        Item item;
        item = UIManager.instance.itemHoldObjectTransition;
        UIManager.instance.itemHoldObjectTransition = this.itemStoredInventorySlot;
        this.itemStoredInventorySlot = item;
        item = null;
    }

    public void CancelAction()
    {
        UIManager.instance.itemHoldImage.sprite = null;
        UIManager.instance.itemHoldImage.gameObject.SetActive(false);

        UIManager.instance.itemHoldObjectTransition = null;

        //this.hasEquipment = true;

        this._slotIcon.color = Color.white;
        Debug.Log("aiaiaiaiaaiaiiaiaaiiaiaiaia");
    }
}
