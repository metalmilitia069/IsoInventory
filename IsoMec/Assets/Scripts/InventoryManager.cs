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
    [SerializeField]
    public List<Item> _inventoryList;

    public int inventoryCapacity;
    public bool isfull = false;

    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryCleanup;

    public delegate void OnEquipmentChange();
    public OnInventoryChange onEquipmentChange;

    public delegate void OnInventoryPickup();
    public OnInventoryChange onInventoryPickup;

    public delegate void OnInventoryUpdate();
    public OnInventoryChange onInventoryUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(Item item)
    {
        if(_inventoryList.Count >= inventoryCapacity)
        {
            Debug.Log("Inventory is Full!!!");
            this.isfull = true;
        }
        else
        {
            this._inventoryList.Add(item);
            this.isfull = false;

            //////////////////////////////onInventoryChange();
            //onInventoryPickup();
        }
        
    }

    //public void RemoveFromInventory(int slotIndex)
    public void RemoveFromInventory(Item item)
    {
        //this._inventoryList.RemoveAt(UIManager.instance.transitionItemIndex);
        //this._inventoryList.RemoveAt(slotIndex);
        this._inventoryList.Remove(item);

        ////////////////////////////////////onInventoryChange();
    }

    public void GetItemInformation()
    {

    }
}
