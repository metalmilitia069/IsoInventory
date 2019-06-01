using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFloatingImage : MonoBehaviour
{
    [SerializeField]
    public Image itemFloatingImage;
    [SerializeField]
    public bool hasBeenEnabled = false;

    private void Update()
    {        
        if (!this.hasBeenEnabled)
        {            
            this.itemFloatingImage.gameObject.SetActive(false);
            this.itemFloatingImage.sprite = null;
            this.gameObject.SetActive(false);
            return;
        }
        else if (this.hasBeenEnabled)
        {
            this.itemFloatingImage.transform.position = Input.mousePosition;
            this.itemFloatingImage.sprite = InventoryManager.instance.ItemTransfer.itemIcon;
            this.itemFloatingImage.gameObject.SetActive(true);
        }
    }
}
