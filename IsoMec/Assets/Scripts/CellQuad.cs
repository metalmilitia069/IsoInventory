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
    //[SerializeField]
    //public InventorySlot otherSlot;
    //[SerializeField]
    //public List<InventorySlot> otherSlots;
    //[SerializeField]
    //public Vector2 nextSlotCoords;
    //[SerializeField]
    //public Vector2 maximumCoordenates;
    public List<float> xCoordComponents;
    public List<float> yCoordComponents;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //switch (itemSize.x)
        //{
        //    case 1:
        //        Debug.Log("Already highlighting this slot");
        //        break;
        //    case 2:
        //        for (int i = 1; i <= itemSize.x; i++)//itemSize.x = 2
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x, thisSlot.cellSlotCoordinates.y - (this.QuadrantRule().y + (i * -this.QuadrantRule().y))); //FORMULA = COORD.Y - [(QuadRule.Y) + (i * -(QuadRule.Y))]
        //            if (nextSlotCoords.y > InventoryUIManager.instance.maximumCoordenates.y)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    case 3:
        //        for (int i = 0; i < itemSize.x; i++)//itemSize.x = 3
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x, thisSlot.cellSlotCoordinates.y - (this.QuadrantRule().y + (i * -this.QuadrantRule().y)));
        //            if (nextSlotCoords.y > InventoryUIManager.instance.maximumCoordenates.y)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    case 4:
        //        for (int i = 0; i < itemSize.x; i++)//itemSize.x = 4
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x, thisSlot.cellSlotCoordinates.y - (this.QuadrantRule().y + (i * -this.QuadrantRule().y)));
        //            if (nextSlotCoords.y > InventoryUIManager.instance.maximumCoordenates.y)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    //InventorySlot otherSlot;
        //    //UIManager.instance.listOfinventorySlots.IndexOf(this.thisSlot);
        //    default:
        //        break;
        //}
        //switch (itemSize.y)
        //{
        //    case 1:
        //        Debug.Log("Already highlighting this slot");
        //        break;
        //    case 2:
        //        for (int i = 1; i <= itemSize.y; i++)//itemSize.y = 2
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x - (this.QuadrantRule().x + (i * -this.QuadrantRule().x)), thisSlot.cellSlotCoordinates.y); //FORMULA = COORD.Y - [(QuadRule.Y) + (i * -(QuadRule.Y))]
        //            if (nextSlotCoords.x > InventoryUIManager.instance.maximumCoordenates.x)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    case 3:
        //        for (int i = 0; i < itemSize.y; i++)//itemSize.y = 2
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x - (this.QuadrantRule().x + (i * -this.QuadrantRule().x)), thisSlot.cellSlotCoordinates.y); //FORMULA = COORD.Y - [(QuadRule.Y) + (i * -(QuadRule.Y))]
        //            if (nextSlotCoords.x > InventoryUIManager.instance.maximumCoordenates.x)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    case 4:
        //        for (int i = 0; i < itemSize.y; i++)//itemSize.y = 2
        //        {
        //            nextSlotCoords = new Vector2(thisSlot.cellSlotCoordinates.x - (this.QuadrantRule().x + (i * -this.QuadrantRule().x)), thisSlot.cellSlotCoordinates.y); //FORMULA = COORD.Y - [(QuadRule.Y) + (i * -(QuadRule.Y))]
        //            if (nextSlotCoords.x > InventoryUIManager.instance.maximumCoordenates.x)//OR slot is taken//
        //            {
        //                Debug.Log("the slot does not exit!!!!");
        //                return;
        //            }
        //            string slotName = $"Slot[{nextSlotCoords.x},{nextSlotCoords.y}]";
        //            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.listOfinventorySlots)
        //            {
        //                if (inventorySlot.name == slotName)
        //                {
        //                    otherSlots.Add(inventorySlot);
        //                    inventorySlot.ShadeSlot();
        //                }
        //            }
        //        }
        //        break;
        //    default:
        //        break;
        //}
        //switch (itemSize.ToString())
        //{
        //    case "(0.0, 0.0)":
        //        Debug.Log("AIAIAAIAIAIA CARRAPATO NAO TEM PAI!!!!!!!!!!!");
        //        break;
        //    default:
        //        break;
        //}

        //xCoordComponents = new List<float>();
        //yCoordComponents = new List<float>();


        
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
                        //otherSlots.Add(inventorySlot);
                        inventorySlot.ShadeSlot();
                        InventoryUIManager.instance.groupOfSelectedInventorySlots.Add(inventorySlot);
                    }
                }
            }
        }
        //xCoordComponents.Sort()
        //InventoryUIManager.instance.groupOfSelectedInventorySlots = otherSlots;
        //xCoordComponents.Clear();
        //yCoordComponents.Clear();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        xCoordComponents.Clear();
        yCoordComponents.Clear();
        foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
        {
            inventorySlot.UnshadeSlot();
        }
        //otherSlots.Clear();
        InventoryUIManager.instance.groupOfSelectedInventorySlots.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        QuadrantRule();
        Debug.Log(itemSize.ToString());
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
