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
    [SerializeField]
    public Item ItemTransfer;

    public void AddToInventory(Item item)
    {
        if (item.isStackable)
        {
            foreach (Item stackableItem in this.inventoryList)
            {
                if (item.itemName == stackableItem.itemName)
                {
                    stackableItem.itemCounter++;
                    //Destroy(item.gameObject);
                    //break;
                    return;
                }
            }
            
        }
        if (inventoryList.Count < _inventoryCapacity)
        {
            //item.itemCounter++;
            this.isFull = false;
            this.inventoryList.Add(item);            
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
            }
            UIManager.instance.RemoveFromInventorySlot(UIManager.instance.listOfinventorySlots[i]);
        }        

        UIManager.instance.OnItemRemoved();

        for (int i = 0; i < this.inventoryList.Count; i++)
        {
            UIManager.instance.AddToInventorySlotOnPickup(this.inventoryList[i]);
        }
        EventManager.instance.onItemPickup();
    }

    public void RemoveFromInventory(Item item)
    {
        this.inventoryList.Remove(item);        
    }

    //EXAMPLE OF EVENTS / DELEGATES
    //public delegate void OnInventoryChange();
    //public OnInventoryChange onInventoryCleanup;
    //InventoryManager.instance.onInventoryCleanup += CleanupInventory;

    
}
