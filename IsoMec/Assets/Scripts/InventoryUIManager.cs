using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    #region Singleton

    public static InventoryUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion


    [Header("INVENTORY UI")]
    public List<InventorySlot> listOfinventorySlots;
    [SerializeField]
    public Vector2 maximumCoordenates;
    [SerializeField]
    public List<InventorySlot> groupOfSelectedInventorySlots;
    [SerializeField]
    public Dictionary<Vector2, InventorySlot> dictionaryOfInventorySlots;


    [Header("TEST!!!! DELETE LATER!!!")]
    [SerializeField]
    //public ItemFloatingImage ItemFloatingImage;
    public Button itemUIButton; //TODO: GAMBIARRA!!!!!!!

    private void Start()
    {
        //listOfinventorySlots.Remove(new Vector2(1f, 1f)); .(FindObjectsOfType<InventorySlot>());
        //dictionaryOfInventorySlots.OrderBy(x => x.Key);
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());

        
       
        InventoryUIManager.instance.listOfinventorySlots = InventoryUIManager.instance.listOfinventorySlots.OrderBy(tile => tile.name).ToList();



        CalculateMaximunCoordinates();
        //itemUIButton.image.rectTransform.sizeDelta = new Vector2(30f, 45f);
    }
    

    private void CalculateMaximunCoordinates()
    {       
        for (int i = 0; i < listOfinventorySlots.Count; i++)
        {
            if (maximumCoordenates.x <= listOfinventorySlots[i].cellSlotCoordinates.x)
            {
                maximumCoordenates.x = listOfinventorySlots[i].cellSlotCoordinates.x;
                if (maximumCoordenates.y <= listOfinventorySlots[i].cellSlotCoordinates.y)
                {
                    maximumCoordenates.y = listOfinventorySlots[i].cellSlotCoordinates.y;
                    Debug.Log("repetindo adoidado");
                }
            }
        }
    }

    public void AddtoInventoryUI(Item item)
    {
        itemUIButton.image.rectTransform.sizeDelta = new Vector2(15f * item.itemInventorySize.x, 15f * item.itemInventorySize.y);
        //this.listOfinventorySlots.Sort();
        int count = 0;
        //while (count < this.listOfinventorySlots.Count)
        //{
            //int k;
            //int l;
        //for (int w = 0; w < this.listOfinventorySlots.Count; w++)
        //{
        //    for (int i = 0; i < item.itemInventorySize.y; i++)//TODO: gambiarra!!!
        //    {
        //        for (int j = 0; j < item.itemInventorySize.x; j++)
        //        {
        //            k = ((i * 10) + (j * 1));
        //            if (this.listOfinventorySlots[k].storedItem == null)
        //            {
        //                this.groupOfSelectedInventorySlots.Add(this.listOfinventorySlots[k]);
        //            }
        //            else
        //            {

        //            }
        //        }

        //    }
        //}

        int k = 0;
        int l = 0;
        int i = 0;
        int j = 0;
        int q = 0;
        bool done = false;

        //for (int w = 0; w < this.listOfinventorySlots.Count; w++)
        //{            
        //    j = 0;
        //    while (i < item.itemInventorySize.y + l)
        //    {
        //        //q = j;
        //        //if (!locked)
        //        //{
        //        //    j = 0;
        //        //}
        //        //j = 0;                
        //        while (j < item.itemInventorySize.x + q)
        //        {
        //            k = ((i * 10) + (j * 1));
        //            if (this.listOfinventorySlots[k].storedItem == null)
        //            {
        //                this.groupOfSelectedInventorySlots.Add(this.listOfinventorySlots[k]);
        //                this.listOfinventorySlots[k].storedItem = item;
        //                j++;
        //                locked = false;
        //                //return;
        //            }
        //            else
        //            {
        //                locked = true;
        //                //i = (int)groupOfSelectedInventorySlots.First().cellSlotCoordinates.y;
        //                //j = (int)groupOfSelectedInventorySlots.First().cellSlotCoordinates.x;
        //                i = k / 10;
        //                j = k % 10;
        //                j++;
        //                l = i;
        //                q = j;
        //                this.groupOfSelectedInventorySlots.Clear();



        //                if (j > this.maximumCoordenates.x)
        //                {
        //                    j = 0;
        //                    //l = i+ 1;
        //                }
        //                if (i > this.maximumCoordenates.y)
        //                {
        //                    Debug.Log("inventory is full");
        //                    break;
        //                }
        //                break;
        //                //i = k / 10;
        //                //j = k % 10;

        //                //j++;
        //            }
        //            //j++;
        //        }
        //        if (!locked)
        //        {
        //            i++;
        //            //j = 0;
        //        }

        //        //l = i;
        //    }
        //}

        for (int w = 0; w < this.listOfinventorySlots.Count; w++)
        {
            if (done)
            {
                break;
            }
            j = w % 10;
            i = w / 10;
            q = j;
            l = i;
            if (j > this.maximumCoordenates.x)
            {
                j = 0;
            }

            while (i < item.itemInventorySize.y + l)
            {
                j = w % 10;
                while (j < item.itemInventorySize.x + q)
                {
                    k = ((i * 10) + (j * 1));
                    if (this.listOfinventorySlots[k].storedItem == null)
                    {
                        this.groupOfSelectedInventorySlots.Add(this.listOfinventorySlots[k]);
                        this.listOfinventorySlots[k].storedItem = item;
                        j++;
                        done = true;
                        //return;
                    }
                    else
                    {
                        foreach (InventorySlot inventorySlot in groupOfSelectedInventorySlots)
                        {
                            inventorySlot.storedItem = null;
                        }
                        this.groupOfSelectedInventorySlots.Clear();
                        done = false;
                        j = (int)item.itemInventorySize.x + q;
                        i = (int)item.itemInventorySize.y + l;
                        //if (j > this.maximumCoordenates.x)
                        //{
                        //    j = 0;
                        //    //l = i+ 1;
                        //}
                        if (i > this.maximumCoordenates.y)
                        {
                            Debug.Log("inventory is full");
                            break;
                        }
                        break;                       
                    }
                    //j++;
                }
                i++;
            }
        }



        //break;

        //}
        this.PutItemIconButtonIntoInventoryUI();
    }

    public void PutItemIconButtonIntoInventoryUI()
    {
        if (InventoryUIManager.instance.groupOfSelectedInventorySlots.Count > 0)
        {
            Debug.Log("mozo");
            float x = 0;
            float y = 0;
            float centerX = 0;
            float centerY = 0;
            foreach (InventorySlot inventorySlot in InventoryUIManager.instance.groupOfSelectedInventorySlots)
            {
                x += inventorySlot.transform.position.x;

                y += inventorySlot.transform.position.y;
            }
            centerX = x / InventoryUIManager.instance.groupOfSelectedInventorySlots.Count;
            centerY = y / InventoryUIManager.instance.groupOfSelectedInventorySlots.Count;

            //InventoryUIManager.instance.ItemFloatingImage.transform.position.x = centerX;
            //InventoryUIManager.instance.ItemFloatingImage.transform.position.y = centerY;
            InventoryUIManager.instance.itemUIButton.transform.position = new Vector3(centerX, centerY, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
