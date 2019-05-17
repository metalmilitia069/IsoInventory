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
        InventoryManager.instance.onInventoryChange += UpdateInventoryUI;
        

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

    private void UpdateInventoryUI()
    {
        if (InventoryManager.instance._inventoryList != null)
        {
            for (int i = 0; i < _arrayOfSlotsUI.Length; i++)
            {
                _arrayOfSlotsUI[i]._slotIcon.sprite = null;
                _arrayOfSlotsUI[i]._slotIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);  //PS.: must be values between 0-1. Get the values on the Inspector, then divide them by /255 >> example: here, I wanted the color (161,87,87)
                //so, I need to calculate 161/255, 87/255 and 87/255 with alpha 255/255 = 1                
                _arrayOfSlotsUI[i].itemStoredInventorySlot = null;
            }
            foreach (Item item in InventoryManager.instance._inventoryList)
            {                
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.sprite = item.itemIcon;
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.color = Color.white;                
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex].itemStoredInventorySlot = item;
                index++;
            }
        }
        index = 0;
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
    
    //private void U
}
