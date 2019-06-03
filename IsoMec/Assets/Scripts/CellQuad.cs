using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellQuad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField]
    //public Image cellImage;
    [SerializeField]
    [Range(1,4)]
    public int quadNumber;
    [SerializeField]
    public Vector2 itemSize;
    [SerializeField]
    public InventorySlot thisSlot;
    [SerializeField]
    public InventorySlot otherSlot;
    [SerializeField]
    public InventorySlot[] otherSlots;
    //[SerializeField]
    //public Vector2 maximumCoordenates;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (itemSize.x)
        {
            case 1:
                Debug.Log("Already highlighting this slot");
                break;
            case 2:
                for (int i = 0; i < InventoryUIManager.instance.listOfinventorySlots.Capacity; i++)
                {
                    //if (UIManager.instance.listOfinventorySlots[i].name == $"Slot[{thisSlot.cellSlotCoordinates.x},{thisSlot.cellSlotCoordinates.y + this.QuadrantRule().y}]")
                    //{
                    //    //UIManager.instance.listOfinventorySlots[i].ShadeSlot();
                    //    otherSlot = UIManager.instance.listOfinventorySlots[i];
                    //    otherSlot.ShadeSlot();
                    //}

                }
                break;
            case 3:
                for (int i = 0; i < InventoryUIManager.instance.listOfinventorySlots.Capacity; i++)
                {
                    if (InventoryUIManager.instance.listOfinventorySlots[i].name == $"Slot[{thisSlot.cellSlotCoordinates.x},{thisSlot.cellSlotCoordinates.y + this.QuadrantRule().y}]")
                    {
                        //UIManager.instance.listOfinventorySlots[i].ShadeSlot();
                        otherSlot = InventoryUIManager.instance.listOfinventorySlots[i];
                        otherSlot.ShadeSlot();
                        FindObjectOfType<InventorySlot>().name = "mozo";
                        
                    }
                }
                break;
            //InventorySlot otherSlot;
            //UIManager.instance.listOfinventorySlots.IndexOf(this.thisSlot);
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //for (int i = 0; i < UIManager.instance.listOfinventorySlots.Capacity; i++)
        //{           
        //    UIManager.instance.listOfinventorySlots[i].UnshadeSlot();            
        //}
        //otherSlot.UnshadeSlot();
    }

    // Start is called before the first frame update
    void Start()
    {
        QuadrantRule();

        //for (int i = 0; i < InventoryUIManager.instance.listOfinventorySlots.Capacity; i++)
        //{
        //    if (maximumCoordenates.x < InventoryUIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.x)
        //    {
        //        maximumCoordenates.x = InventoryUIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.x;
        //        if (maximumCoordenates.y < InventoryUIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.y)
        //        {
        //            maximumCoordenates.y = InventoryUIManager.instance.listOfinventorySlots[i].cellSlotCoordinates.y;
        //            Debug.Log("repetindo adoidado");
        //        }
        //    }
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 QuadrantRule()
    {
        switch (quadNumber)
        {
            case 1:
                return new Vector2(-1f,-1f);
            case 2:
                return new Vector2(1f,1f);
            case 3:
                return new Vector2(-1f, -1f);
            case 4:
                return new Vector2(1f, 1f);
            default:
                Debug.Log("WARNING: You should select as quad number from 1 to 4");
                return new Vector2(0, 0);
        }
    }
}
