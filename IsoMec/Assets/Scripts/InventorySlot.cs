using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : UISlotsBase, IPointerExitHandler//,IPointerEnterHandler
{
    //public GameObject lalagameObject;
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if(this.storedItem != null)
    //    {
    //        base.ShowItemStats();
            
    //    }        
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    base.HideItemStats();
    //    //Instantiate(gameObject, this.transform.position, Quaternion.identity);
        
    //}

    private void Start()
    {
        //this.GetComponent<GridLayoutGroup>().cellSize = InventoryManager.instance.cellSize / 2;
        //GameObject mozo = Instantiate(lalagameObject, this.transform.position, Quaternion.identity);
        //mozo.transform.parent = this.transform;
        ////mozo.GetComponent<Image>().rectTransform.set
        //mozo.transform.name = "Cell[1,1]";
        //Debug.Log("ein?");
    }
}
