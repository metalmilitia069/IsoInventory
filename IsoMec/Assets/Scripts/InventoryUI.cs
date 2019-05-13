using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //[SerializeField]
    //private Image[] _inventorySlotIcons;
    [SerializeField]
    private List<Image> _inventorySlotIcons;
    [SerializeField]
    private int _InventorySize;
    

    private int index = 0;

    private void Start()
    {
        //double[] balance = new double[10];
        //Image[] _inventorySlotIcons = new Image[10];
        //_inventorySlotIcons. = 10;
    }

    // Update is called once per frame
    void Update()
    {

        //_inventorySlotIcons.Capacity = 10;

        if (InventoryManager.instance._inventoryList != null)
        {
            foreach (Item item in InventoryManager.instance._inventoryList)
            {
                _inventorySlotIcons[index].sprite = item.itemIconPlaceHolder;
                _inventorySlotIcons[index].color = Color.white;
                index++;
            }
        }
        index = 0;
    }
}
