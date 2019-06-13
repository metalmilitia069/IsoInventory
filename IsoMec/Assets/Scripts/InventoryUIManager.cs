﻿using System.Collections;
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
    [SerializeField]
    public Dictionary<Vector2, InventorySlot> dictionaryOfInventorySlots;


    [Header("TEST!!!! DELETE LATER!!!")]
    [SerializeField]
    //public ItemFloatingImage ItemFloatingImage;
    public Button itemUIButton; //TODO: GAMBIARRA!!!!!!!
    bool done = false;

    private void Start()
    {
        //listOfinventorySlots.Remove(new Vector2(1f, 1f)); .(FindObjectsOfType<InventorySlot>());
        //dictionaryOfInventorySlots.OrderBy(x => x.Key);
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());

        
       
        InventoryUIManager.instance.listOfinventorySlots = InventoryUIManager.instance.listOfinventorySlots.OrderBy(tile => tile.name).ToList();



        CalculateMaximunCoordinates();
        //itemUIButton.image.rectTransform.sizeDelta = new Vector2(30f, 45f);
    }
    

    private void CalculateMaximunCoordinates()
    {       
        for (int i = 0; i < listOfinventorySlots.Count; i++)
        {
            if (maximumCoordenates.x <= listOfinventorySlots[i].cellSlotCoordinates.x)
            {
                maximumCoordenates.x = listOfinventorySlots[i].cellSlotCoordinates.x;
                if (maximumCoordenates.y <= listOfinventorySlots[i].cellSlotCoordinates.y)
                {
                    maximumCoordenates.y = listOfinventorySlots[i].cellSlotCoordinates.y;
                    Debug.Log("repetindo adoidado");
                }
            }
        }
    }

    public void AddtoInventoryUI(Item item)
    {
        itemUIButton.image.rectTransform.sizeDelta = new Vector2(15f * item.itemInventorySize.x, 15f * item.itemInventorySize.y);

        int k = 0;
        int l = 0;
        int i = 0;
        int j = 0;
        int q = 0;
        done = false;        

        for (int w = 0; w < this.listOfinventorySlots.Count; w++)
        {
            if (done)
            {
                break;
            }
            
            j = (int)listOfinventorySlots[w].cellSlotCoordinates.y;
            i = (int)listOfinventorySlots[w].cellSlotCoordinates.x;
            q = j;
            l = i;            

            while (i < item.itemInventorySize.y + l)
            {                
                j = (int)listOfinventorySlots[w].cellSlotCoordinates.y;
                
                while (j < item.itemInventorySize.x + q)
                {
                    foreach (InventorySlot inventorySlot in listOfinventorySlots)
                    {
                        //if (inventorySlot.name == $"Slot[{i},{j}]")
                        if(inventorySlot.cellSlotCoordinates == new Vector2(i,j))
                        {
                            k = this.listOfinventorySlots.IndexOf(inventorySlot);
                            break;
                        }
                    }
                    if (this.listOfinventorySlots[k].storedItem == null)
                    {
                        this.groupOfSelectedInventorySlots.Add(this.listOfinventorySlots[k]);
                        this.listOfinventorySlots[k].storedItem = item;
                        j++;
                        done = true;
                    }
                    else
                    {
                        Debug.Log("chonga");
                        foreach (InventorySlot inventorySlot in groupOfSelectedInventorySlots)
                        {
                            inventorySlot.storedItem = null;
                        }
                        this.groupOfSelectedInventorySlots.Clear();
                        done = false;
                        j = (int)item.itemInventorySize.x + q;
                        i = (int)item.itemInventorySize.y + l;                                             
                    }                    
                }
                i++;
            }
        }

        if (groupOfSelectedInventorySlots.Count == 0)
        {
            Debug.Log("Inventory is Full!");
            item.PickableItem = false;            
        }
        else
        {
            this.PutItemIconButtonIntoInventoryUI();
        }
    }

    public void PutItemIconButtonIntoInventoryUI()
    {
        if (InventoryUIManager.instance.groupOfSelectedInventorySlots.Count > 0)
        {
            Debug.Log("mozo");
            float x = 0;
            float y = 0;
            float centerX = 0;
            float centerY = 0;
            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
            {
                x += inventorySlot.transform.position.x;

                y += inventorySlot.transform.position.y;
            }
            centerX = x / InventoryUIManager.instance.groupOfSelectedInventorySlots.Count;
            centerY = y / InventoryUIManager.instance.groupOfSelectedInventorySlots.Count;

            //InventoryUIManager.instance.ItemFloatingImage.transform.position.x = centerX;
            //InventoryUIManager.instance.ItemFloatingImage.transform.position.y = centerY;
            InventoryUIManager.instance.itemUIButton.transform.position = new Vector3(centerX, centerY, 0);
            this.groupOfSelectedInventorySlots[0].storedItem.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
