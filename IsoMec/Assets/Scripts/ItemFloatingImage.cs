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
            this.gameObject.SetActive(false);
            this.itemFloatingImage.sprite = null;
            //Debug.Log("paradise");
            //return;
        }
        else if (this.hasBeenEnabled)
        {
            //Debug.Log("lalalall lololol");
            this.itemFloatingImage.transform.position = Input.mousePosition;
            this.itemFloatingImage.sprite = InventoryManager.instance.ItemTransfer.itemIcon;
            this.itemFloatingImage.gameObject.SetActive(true);
        }
    }
}
