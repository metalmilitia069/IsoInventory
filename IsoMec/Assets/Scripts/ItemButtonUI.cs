using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonUI : MonoBehaviour
{
    [SerializeField]
    public Item itemReference;
    [SerializeField]
    public Image buttonImage;
    [SerializeField]
    public List<InventorySlot> listOfItemSlotsReference = new List<InventorySlot>();


    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = itemReference.itemIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrabItemButton()
    {
        InventoryUIManager.instance.itemButtonReference = this.GetComponent<Button>();
        InventoryUIManager.instance.canGrabButton = true;
        InventoryUIManager.instance.itemButtonReference.image.raycastTarget = false;

        foreach (InventorySlot inventorySlot in this.listOfItemSlotsReference)
        {
            inventorySlot.storedItem = null;
            UIShaderManager.instance.UnshadeSlots(inventorySlot);
        }
        this.RemoveSlotsReferenceFromButton();
    }

    public void AddSlotsReferenceToButton()
    {
        int numberOFSlots = (int)(itemReference.itemInventorySize.x * itemReference.itemInventorySize.y);
       
        for (int i = 0; i < InventoryUIManager.instance.groupOfSelectedInventorySlots.Count; i++)
        {
            this.listOfItemSlotsReference.Add(InventoryUIManager.instance.groupOfSelectedInventorySlots[i]);
            this.listOfItemSlotsReference[i].storedItem = this.itemReference;
        }
    }

    public void RemoveSlotsReferenceFromButton()
    {
        this.listOfItemSlotsReference.Clear();
    }
}
