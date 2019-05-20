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

    public void AddToInventory(Item item)
    {
        this.inventoryList.Add(item);
        EventManager.instance.onAddToInventory();
    }

    //EXAMPLE OF EVENTS / DELEGATES
    //public delegate void OnInventoryChange();
    //public OnInventoryChange onInventoryCleanup;
    //InventoryManager.instance.onInventoryCleanup += CleanupInventory;

    
}
