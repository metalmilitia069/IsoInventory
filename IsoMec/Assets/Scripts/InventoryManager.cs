using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton

    public static InventoryManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public List<Item> inventoryList;
    public bool isFull = false;

    [SerializeField]
    private int _inventoryCapacity;

    public void AddToInventory(Item item)
    {
        if (inventoryList.Count < _inventoryCapacity)
        {
            this.isFull = false;
            this.inventoryList.Add(item);
            UIManager.instance.AddToInventorySlot(item);

            OrganizeInventoryList();
        }
        else
        {
            Debug.Log("Inventory is Full");
            this.isFull = true;
        }

    }

    public void OrganizeInventoryList()
    {
        this.inventoryList.Clear();

        for (int i = 0; i < UIManager.instance.listOfinventorySlots.Count; i++)
        {
            if (UIManager.instance.listOfinventorySlots[i].storedItem != null)
            {
                this.inventoryList.Add(UIManager.instance.listOfinventorySlots[i].storedItem);
                EventManager.instance.onItemPickup();
            }            
        }
    }

    //EXAMPLE OF EVENTS / DELEGATES
    //public delegate void OnInventoryChange();
    //public OnInventoryChange onInventoryCleanup;
    //InventoryManager.instance.onInventoryCleanup += CleanupInventory;

    
}
