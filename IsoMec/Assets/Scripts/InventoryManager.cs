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
    public OnInventoryChange onInventoryChange;

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

            onInventoryChange();
        }
        
    }

    public void GetItemInformation()
    {

    }
}
