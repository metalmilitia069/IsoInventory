using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    public List<InventorySlot> groupOfSelectedInventorySlots;


    [Header("TEST!!!! DELETE LATER!!!")]
    [SerializeField]
    //public ItemFloatingImage ItemFloatingImage;
    public Button itemUIButton;

    private void Start()
    {
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());
        InventoryUIManager.instance.listOfinventorySlots = InventoryUIManager.instance.listOfinventorySlots.OrderBy(tile => tile.name).ToList();

        CalculateMaximunCoordinates();
        itemUIButton.image.rectTransform.sizeDelta = new Vector2(30f, 45f);
    }
    

    private void CalculateMaximunCoordinates()
    {       
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

    public void AddtoInventoryUI(Item item)
    {
        this.listOfinventorySlots.Sort();
        int count = 0;
        while (count < this.listOfinventorySlots.Count)
        {
            int k;
            int l;
            for (int i = 0; i < item.itemInventorySize.x; i++)
            {
                for (int j = 0; j < item.itemInventorySize.y; j++)
                {
                    //if (this.listOfinventorySlots)
                    //{

                    //}
                }
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
