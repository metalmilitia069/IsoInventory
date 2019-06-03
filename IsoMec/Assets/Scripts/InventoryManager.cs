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
    [Header("Inventory Configuration",order = 0)]   
    [SerializeField]
    public int inventoryCapacity;
    [Space]
    [SerializeField]
    public int numberOfColumns;
    [Space]
    [SerializeField]
    public Vector2 cellSize;
    
}
