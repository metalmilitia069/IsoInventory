using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{    
    [SerializeField]
    private InventorySlot[] _arrayOfSlotsUI;
    [SerializeField]
    private List<CharacterSlot> _listOfCharacterEquiSlotsUI;
    
    private int index = 0;

    private void Start()
    {        
        InventoryManager.instance.onInventoryCleanup += CleanupInventory;
        InventoryManager.instance.onEquipmentChange += UpdateEquipmentUI;
        InventoryManager.instance.onInventoryPickup += InventoryPickup;
        InventoryManager.instance.onInventoryUpdate += InventoryUpdate;

        _arrayOfSlotsUI = FindObjectsOfType<InventorySlot>();
        int index = _arrayOfSlotsUI.Length - 1;
        foreach (InventorySlot item in _arrayOfSlotsUI)
        {   
            item._slotIndex = index;
            index--;
        }

        
        _listOfCharacterEquiSlotsUI.AddRange(FindObjectsOfType<CharacterSlot>());
        
    }

    // Update is called once per frame
    void Update()
    {

        //_inventorySlotIcons.Capacity = 10;

        //if (InventoryManager.instance._inventoryList != null)
        //{
        //    foreach (Item item in InventoryManager.instance._inventoryList)
        //    {
        //        _inventorySlotIcons[index].sprite = item.itemIconPlaceHolder;
        //        _inventorySlotIcons[index].color = Color.white;
        //        index++;
        //    }
        //}
        //index = 0;
    }

    private void CleanupInventory()
    {
        if (InventoryManager.instance._inventoryList != null)
        {
            for (int i = 0; i < _arrayOfSlotsUI.Length; i++)
            {
                _arrayOfSlotsUI[i]._slotIcon.sprite = null;
                _arrayOfSlotsUI[i]._slotIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);  //PS.: must be values between 0-1. Get the values on the Inspector, then divide them by /255 >> example: here, I wanted the color (161,87,87)
                //so, I need to calculate 161/255, 87/255 and 87/255 with alpha 255/255 = 1                
                _arrayOfSlotsUI[i].itemStoredInventorySlot = null;
                _arrayOfSlotsUI[i].hasEquipment = false;                
            }
            foreach (Item item in InventoryManager.instance._inventoryList)
            {                
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.sprite = item.itemIcon;
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.color = Color.white;                
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].itemStoredInventorySlot = item;
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].hasEquipment = true;
                index++;
            }
        }
        index = 0;       
    }

    private void InventoryUpdate()
    {
        index = 0;
        if (InventoryManager.instance._inventoryList != null)
        {
            for (int i = 0; i < _arrayOfSlotsUI.Length; i++)
            {
                if (_arrayOfSlotsUI[i].hasEquipment == false)
                {
                    _arrayOfSlotsUI[i]._slotIcon.sprite = null;
                    _arrayOfSlotsUI[i]._slotIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);  //PS.: must be values between 0-1. Get the values on the Inspector, then divide them by /255 >> example: here, I wanted the color (161,87,87)
                                                                                                                           //so, I need to calculate 161/255, 87/255 and 87/255 with alpha 255/255 = 1                
                    _arrayOfSlotsUI[i].itemStoredInventorySlot = null;
                }
                index++;
            }            
        }
        //index = 0;
    }

    private void InventoryPickup()
    {
        index = 0;
        //foreach (Item item in InventoryManager.instance._inventoryList)
        //{
        //    if (_arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].itemStoredInventorySlot == null)
        //    {
        //        _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.sprite = item.itemIcon;
        //        _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.color = Color.white;
        //        _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].itemStoredInventorySlot = item;
        //        _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].hasEquipment = true;
        //        break;
        //    }
        //    index++;            
        //}
        for (int i = 0; i < _arrayOfSlotsUI.Length; i++)
        {
            if (_arrayOfSlotsUI[_arrayOfSlotsUI[i]._slotIndex].itemStoredInventorySlot == null)
            {
                int lastIndex = InventoryManager.instance._inventoryList.Count - 1;
                _arrayOfSlotsUI[_arrayOfSlotsUI[i]._slotIndex]._slotIcon.sprite = InventoryManager.instance._inventoryList[lastIndex].itemIcon;
                _arrayOfSlotsUI[_arrayOfSlotsUI[i]._slotIndex]._slotIcon.color = Color.white;
                _arrayOfSlotsUI[_arrayOfSlotsUI[i]._slotIndex].itemStoredInventorySlot = InventoryManager.instance._inventoryList[lastIndex];
                _arrayOfSlotsUI[_arrayOfSlotsUI[i]._slotIndex].hasEquipment = true;
                break;
            }
        }
    }
    
    private void UpdateEquipmentUI()
    {
        if (CharacterEquipmentManager.instance.characterEquipmentList != null)
        {
            //for (int i = 0; i < _listOfCharacterEquiSlotsUI.Count; i++)
            //{
            //    _listOfCharacterEquiSlotsUI[i]._slotIcon.sprite = null;
            //    _listOfCharacterEquiSlotsUI[i]._slotIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);

            //    _listOfCharacterEquiSlotsUI[i].itemStoredEquipmentPiece = null;
            //}

            //foreach (Item item in CharacterEquipmentManager.instance.characterEquipmentList)
            //{
            //    _listOfCharacterEquiSlotsUI[index]._slotIcon.sprite = item.itemIcon;
            //    _listOfCharacterEquiSlotsUI[index]._slotIcon.color = Color.white;
            //    _listOfCharacterEquiSlotsUI[index].itemStoredEquipmentPiece = item;
            //    index++;
            //}
            foreach (CharacterSlot characterSlot in _listOfCharacterEquiSlotsUI)
            {
                //if (characterSlot.hasEquipment == true)
                //{
                //    characterSlot._slotIcon.sprite = characterSlot.itemStoredEquipmentPiece.itemIcon;
                //    characterSlot._slotIcon.color = Color.white;                    
                //}
                if (characterSlot.hasEquipment == false)
                {
                    characterSlot._slotIcon.sprite = null;
                    characterSlot._slotIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);
                    characterSlot.itemStoredEquipmentPiece = null;
                    //characterSlot.itemStoredEquipmentPiece = null;
                }
            }
        }
        index = 0;
    }

    public void CleanTheInventory()
    {
        InventoryManager.instance.onInventoryCleanup();
    }
}
