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

    private void Start()
    {
        //InventoryManager.instance.onInventoryChange += UpdateItemInventorySlot;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mousing over here");
        
        if (this._slotIndex < InventoryManager.instance._inventoryList.Count)
        {
            UIManager.instance.itemInformationPanel.gameObject.SetActive(true);
            
            UIManager.instance._itemName.text = InventoryManager.instance._inventoryList[this._slotIndex]._itemName;
            UIManager.instance._itemName.color = InventoryManager.instance._inventoryList[this._slotIndex]._itemNameFloatText.color;
            UIManager.instance._itemStatsText.text = "Attack Damage: " + "\n" + "Attack Range: " + "\n" + "Critical Chance: " + "\n" + "Elemental Damage: ";
            UIManager.instance._itemStatsTextNumbers.text = InventoryManager.instance._inventoryList[this._slotIndex].attackDamage.ToString() + "\n"
                + InventoryManager.instance._inventoryList[this._slotIndex].attackRange.ToString() + "\n"
                + InventoryManager.instance._inventoryList[this._slotIndex].criticalChance.ToString() + "\n"
                + InventoryManager.instance._inventoryList[this._slotIndex].elementalDamage;

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

            return;
        }
        //PLACE Item in Inventory From Equipment
        if (UIManager.instance.itemHoldImage.sprite != null && this.itemStoredInventorySlot == null)
        {
            UIManager.instance.itemHoldImage.sprite = null;
            UIManager.instance.itemHoldImage.gameObject.SetActive(false);

            this.itemStoredInventorySlot = UIManager.instance.itemHoldObjectTransition;
            UIManager.instance.itemHoldObjectTransition = null;

            this._slotIcon.sprite = this.itemStoredInventorySlot.itemIcon;
            this._slotIcon.color = Color.white;

            InventoryManager.instance.AddToInventory(this.itemStoredInventorySlot);
            CharacterEquipmentManager.instance.RemoveFromCharacterEquipment(this.itemStoredInventorySlot);

            return;
        }
    }    
}
