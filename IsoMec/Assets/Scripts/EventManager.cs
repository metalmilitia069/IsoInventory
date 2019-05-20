using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Singleton

    public static EventManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    //public delegate void ClickOnItem();
    //public static event ClickOnItem OnClickedOnItem;
    public delegate void OnAddToInventory();
    public OnAddToInventory onAddToInventory;

    public delegate void OnItemPickup();
    public OnItemPickup onItemPickup;
}
