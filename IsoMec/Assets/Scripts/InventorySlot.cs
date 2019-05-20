using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : UISlotsBase, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField]
    //private GameObject _itemInformationPanel;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.storedItem != null)
        {
            base.ShowItemStats();
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        base.HideItemStats();
    }
}
