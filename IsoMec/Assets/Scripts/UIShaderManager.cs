using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShaderManager : MonoBehaviour
{
    #region Singleton

    public static UIShaderManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    private List<InventorySlot> inventorySlotsList;
    [SerializeField]
    public ShadeColor shadeColor;
    [SerializeField]
    private int counterNull;
    [SerializeField]
    private int counterA;
    [SerializeField]
    private int counterB;    
    [SerializeField]
    public ItemButtonUI transferenceButtonUI;

    private List<string> names = new List<string>();

    private ItemButtonUI itemButtonUI;

    public void ShadeSlots()
    {
        counterNull = 0;
        counterA = 0;
        counterB = 0;        
        
        if (InventoryUIManager.instance.groupOfSelectedInventorySlots != null)
        {            
            for (int i = 0; i < InventoryUIManager.instance.groupOfSelectedInventorySlots.Count; i++)
            {
                if (InventoryUIManager.instance.groupOfSelectedInventorySlots[i].storedItem == null)
                {
                    counterNull++;
                }
                else
                {
                    string name = InventoryUIManager.instance.groupOfSelectedInventorySlots[i].storedItem.name;

                    names.Add(name);
                }
            }

            if (names != null)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    if (names[0] == names[i])
                    {
                        counterA++;
                    }
                    else
                    {
                        counterB++;
                    }
                }
                if (counterB == 0)
                {
                    foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
                    {
                        if (inventorySlot.storedItem != null)
                        {
                            transferenceButtonUI = inventorySlot.storedItem.itemUIButton.GetComponent<ItemButtonUI>();                            
                            break;
                        }
                    }
                }
            }
        }        
        names.Clear();        

        itemButtonUI = InventoryUIManager.instance.itemButtonReference.GetComponent<ItemButtonUI>();
        int itemNumberOfSlots = (int)(itemButtonUI.itemReference.itemInventorySize.x * itemButtonUI.itemReference.itemInventorySize.y);
        Debug.Log("number of slots: " + itemNumberOfSlots.ToString());

        if (counterNull + counterA == InventoryUIManager.instance.groupOfSelectedInventorySlots.Count)
        {
            if (InventoryUIManager.instance.groupOfSelectedInventorySlots.Count != itemNumberOfSlots)
            {
                this.shadeColor = ShadeColor.Red;
            }
            else
            {
                this.shadeColor = ShadeColor.Green;
            }
            
        }
        else if (counterB > 0)
        {
            this.shadeColor = ShadeColor.Red;
        }
        
        ApplyShade();

    }

    public void ApplyShade()
    {
        if (transferenceButtonUI != null)
        {
            for (int i = 0; i < this.transferenceButtonUI.listOfItemSlotsReference.Count; i++)
            {
                for (int j = 0; j < this.transferenceButtonUI.listOfItemSlotsReference[i].cellImage.Length; j++)
                {
                    this.transferenceButtonUI.listOfItemSlotsReference[i].cellImage[j].color = Color.yellow;
                }
            }
        }

        if (InventoryUIManager.instance.groupOfSelectedInventorySlots.Count > 0)
        {
            for (int i = 0; i < InventoryUIManager.instance.groupOfSelectedInventorySlots.Count; i++)
            {                
                for (int j = 0; j < InventoryUIManager.instance.groupOfSelectedInventorySlots[i].cellImage.Length; j++)
                {
                    if (this.shadeColor == ShadeColor.Red)
                    {
                        InventoryUIManager.instance.groupOfSelectedInventorySlots[i].cellImage[j].color = Color.red;
                    }
                    else if (this.shadeColor == ShadeColor.Default)
                    {
                        
                        InventoryUIManager.instance.groupOfSelectedInventorySlots[i].cellImage[j].color = InventoryUIManager.instance.itemButtonReference.GetComponent<ItemButtonUI>().itemReference.itemNameFloatText.color;
                    }
                    else if (this.shadeColor == ShadeColor.Green)
                    {
                        InventoryUIManager.instance.groupOfSelectedInventorySlots[i].cellImage[j].color = Color.green;
                    }                   
                }
            }
        }        
    }

    public void UnshadeSlots(InventorySlot inventorySlot)
    {
        for (int i = 0; i < inventorySlot.cellImage.Length; i++)
        {
            if (inventorySlot.storedItem == null)
            {
                inventorySlot.cellImage[i].color = new Color(1, 1, 1, 100 / 255f);
            }
            else
            {
                inventorySlot.cellImage[i].color = inventorySlot.storedItem.itemNameFloatText.color;
            }
            
        }
    }

    public void UnshadeSlots(ItemButtonUI transferItemButtonUI)
    {
        for (int i = 0; i < transferItemButtonUI.listOfItemSlotsReference.Count; i++)
        {
            for (int j = 0; j < transferItemButtonUI.listOfItemSlotsReference[i].cellImage.Length; j++)
            {
                if (transferItemButtonUI.listOfItemSlotsReference[i].storedItem == null)
                {
                    transferItemButtonUI.listOfItemSlotsReference[i].cellImage[j].color = new Color(1, 1, 1, 100 / 255f);
                }
                else
                {
                    transferItemButtonUI.listOfItemSlotsReference[i].cellImage[j].color = transferItemButtonUI.listOfItemSlotsReference[i].storedItem.itemNameFloatText.color;
                }
            }
        }
        this.transferenceButtonUI = null;
    }


    public enum ShadeColor
    {
        Default,
        Green,
        Yellow,
        Red,
        Transference
    }
}
