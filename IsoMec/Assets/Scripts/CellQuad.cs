using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellQuad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{    
    [SerializeField]
    [Range(1,4)]
    public int quadNumber;
    [SerializeField]
    public Vector2 itemSize;
    [SerializeField]
    public InventorySlot thisSlot;    
    public List<float> xCoordComponents;
    public List<float> yCoordComponents;

    public Item storedItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (InventoryUIManager.instance.itemButtonReference == null)
        {
            return;
        }
        else
        {
            itemSize = InventoryUIManager.instance.itemButtonReference.GetComponent<ItemButtonUI>().itemReference.itemInventorySize;
        }

        if (itemSize.x == 2 || itemSize.x == 1)
        {
            for (int i = 1; i <= itemSize.x; i++)
            {
                yCoordComponents.Add(thisSlot.cellSlotCoordinates.y - (this.QuadrantRule().y + (i * -this.QuadrantRule().y)));
            }
        }
        else
        {
            for (int i = 0; i < itemSize.x; i++)
            {
                yCoordComponents.Add(thisSlot.cellSlotCoordinates.y - (this.QuadrantRule().y + (i * -this.QuadrantRule().y)));
            }
        }
        
        if (itemSize.y == 2 || itemSize.y == 1)
        {
            for (int i = 1; i <= itemSize.y; i++)
            {
                xCoordComponents.Add(thisSlot.cellSlotCoordinates.x - (this.QuadrantRule().x + (i * -this.QuadrantRule().x)));
            }
        }
        else
        {
            for (int i = 0; i < itemSize.y; i++)
            {                
                xCoordComponents.Add(thisSlot.cellSlotCoordinates.x - (this.QuadrantRule().x + (i * -this.QuadrantRule().x)));
            }
        }

        for (int i = 0; i < xCoordComponents.Count; i++)
        {
            for (int j = 0; j < yCoordComponents.Count; j++)
            {
                string slotName = $"Slot[{xCoordComponents[i]},{yCoordComponents[j]}]";
                foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
                {
                    if (inventorySlot.name == slotName)
                    {
                        InventoryUIManager.instance.groupOfSelectedInventorySlots.Add(inventorySlot);
                    }
                }
            }
        }
        UIShaderManager.instance.ShadeSlots();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
        {
            if (inventorySlot.storedItem != null)
            {
                Debug.Log("chubirubis");
                return;
            }            
        }

        InventoryUIManager.instance.canGrabButton = false;
        InventoryUIManager.instance.PutItemIconButtonIntoInventoryUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        xCoordComponents.Clear();
        yCoordComponents.Clear();
        foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
        {
            UIShaderManager.instance.UnshadeSlots(inventorySlot);
        }
        
        InventoryUIManager.instance.groupOfSelectedInventorySlots.Clear();
                
        if (UIShaderManager.instance.transferenceButtonUI != null)
        {
            UIShaderManager.instance.UnshadeSlots(UIShaderManager.instance.transferenceButtonUI);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        QuadrantRule();        
    }   

    public Vector2 QuadrantRule()
    {
        switch (quadNumber)
        {
            case 1:
                return new Vector2(-1f,-1f);
            case 2:
                return new Vector2(-1f,1f);
            case 3:
                return new Vector2(1f, -1f);
            case 4:
                return new Vector2(1f, 1f);
            default:
                Debug.Log("WARNING: You should select as quad number from 1 to 4");
                return new Vector2(0, 0);
        }
    }

    
}
