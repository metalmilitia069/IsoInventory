using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    #region Singleton

    public static InventoryUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    [Header("INVENTORY UI")]
    public List<InventorySlot> listOfinventorySlots;
    [SerializeField]
    public Vector2 maximumCoordenates;

    private void Start()
    {
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());
        CalculateMaximunCoordinates();
    }
    

    private void CalculateMaximunCoordinates()
    {
        //for (int i = 0; i < UIManager.instance.listOfinventorySlots.Capacity; i++)
        //{
        //    if (maximumCoordenates.x < UIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.x)
        //    {
        //        maximumCoordenates.x = UIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.x;
        //        if (maximumCoordenates.y < UIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.y)
        //        {
        //            maximumCoordenates.y = UIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.y;
        //            Debug.Log("repetindo adoidado");
        //        }
        //    }
        //}
        for (int i = 0; i < listOfinventorySlots.Capacity; i++)
        {
            if (maximumCoordenates.x < listOfinventorySlots[i].cellSlotCoordinates.x)
            {
                maximumCoordenates.x = listOfinventorySlots[i].cellSlotCoordinates.x;
                if (maximumCoordenates.y < listOfinventorySlots[i].cellSlotCoordinates.y)
                {
                    maximumCoordenates.y = listOfinventorySlots[i].cellSlotCoordinates.y;
                    Debug.Log("repetindo adoidado");
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());
    }
}
