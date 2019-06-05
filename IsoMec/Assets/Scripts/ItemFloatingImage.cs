using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemFloatingImage : MonoBehaviour
{
    [SerializeField]
    public Image itemFloatingImage;
    [SerializeField]
    public bool hasBeenEnabled = false;

    private void Update()
    {        
        if(this.hasBeenEnabled)
        {
            this.itemFloatingImage.gameObject.SetActive(true);
            this.itemFloatingImage.transform.position = Input.mousePosition;
        }
    }

    public void meopao()
    {
        Debug.Log("lalalala meopao");
        //itemFloatingImage.rectTransform.sizeDelta = new Vector2(30f, 30f);
        //this.transform.position = 
        //foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //{
        //    if (inventorySlot.name == "Slot[8,8]")
        //    {
        //        this.transform.position = inventorySlot.transform.position;
        //        break;
        //    }
        //} 
        //InventoryUIManager.instance.listOfinventorySlots.Sort();
        //tileList = tileList.OrderBy(tile => tile.Name).ToList();
        InventoryUIManager.instance.listOfinventorySlots = InventoryUIManager.instance.listOfinventorySlots.OrderBy(tile => tile.name).ToList();

        //this.transform.position.x = 
    }
}
