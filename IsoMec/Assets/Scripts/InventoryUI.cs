using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //[SerializeField]
    //private Image[] _inventorySlotIcons;
    //[SerializeField]
    //private List<Image> _inventorySlotIcons;
    //[SerializeField]
    //private int _InventorySize;
    //[SerializeField]
    //private List<InventorySlot> _listOfSlotsUI;
    [SerializeField]
    private InventorySlot[] _arrayOfSlotsUI;


    private int index = 0;

    private void Start()
    {
        //double[] balance = new double[10];
        //Image[] _inventorySlotIcons = new Image[10];
        //_inventorySlotIcons. = 10;
        InventoryManager.instance.onInventoryChange += UpdateInventoryUI;

        //int index = 0;

        //_listOfSlotsUI = FindObjectsOfType<InventorySlot>();
        
        _arrayOfSlotsUI = FindObjectsOfType<InventorySlot>();
        int index = _arrayOfSlotsUI.Length - 1;
        foreach (InventorySlot item in _arrayOfSlotsUI)
        {
            
            //_listOfSlotsUI.Add(item);
            item._slotIndex = index;
            index--;
        }
        //_playersList.Add(FindObjectOfType<Player>());
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
            }
            foreach (Item item in InventoryManager.instance._inventoryList)
            {
                //_inventorySlotIcons[index].sprite = item.itemIconPlaceHolder;
                //_inventorySlotIcons[index].color = Color.white;
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.sprite = item.itemIconPlaceHolder;
                _arrayOfSlotsUI[_arrayOfSlotsUI[index]._slotIndex]._slotIcon.color = Color.white;
                //_arrayOfSlotsUI[index]._slotIcon.sprite = item.itemIconPlaceHolder;
                index++;
            }
        }
        index = 0;
    }
}
