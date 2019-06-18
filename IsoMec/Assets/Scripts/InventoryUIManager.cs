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
    [Space]    
    [SerializeField]
    public Button itemButtonReference;
    [SerializeField]
    public 
    bool done = false;
    public bool canGrabButton = false;
    [SerializeField]
    public GameObject floatingItemButtonParent;

    private void Start()
    {       
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());
        InventoryUIManager.instance.listOfinventorySlots = InventoryUIManager.instance.listOfinventorySlots.OrderBy(tile => tile.name).ToList();
        CalculateMaximunCoordinates();        
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
        itemButtonReference = item.GetComponentInChildren<Button>();
        itemButtonReference.image.rectTransform.sizeDelta = new Vector2(InventoryManager.instance.cellSize.x * item.itemInventorySize.x, InventoryManager.instance.cellSize.y * item.itemInventorySize.y);       

        int k = 0;
        int l = 0;
        int i = 0;
        int j = 0;
        int q = 0;
        done = false;        

        for (int w = 0; w < this.listOfinventorySlots.Count; w++)
        {
            if (done)
            {
                break;
            }
            
            j = (int)listOfinventorySlots[w].cellSlotCoordinates.y;
            i = (int)listOfinventorySlots[w].cellSlotCoordinates.x;
            q = j;
            l = i;            

            while (i < item.itemInventorySize.y + l)
            {                
                j = (int)listOfinventorySlots[w].cellSlotCoordinates.y;
                
                while (j < item.itemInventorySize.x + q)
                {
                    foreach (InventorySlot inventorySlot in listOfinventorySlots)
                    {                        
                        if(inventorySlot.cellSlotCoordinates == new Vector2(i,j))
                        {
                            k = this.listOfinventorySlots.IndexOf(inventorySlot);
                            break;
                        }
                    }
                    if (this.listOfinventorySlots[k].storedItem == null)
                    {
                        this.groupOfSelectedInventorySlots.Add(this.listOfinventorySlots[k]);

                        this.listOfinventorySlots[k].storedItem = item;
                        j++;
                        done = true;
                    }
                    else
                    {
                        Debug.Log("chonga");
                        foreach (InventorySlot inventorySlot in groupOfSelectedInventorySlots)
                        {
                            inventorySlot.storedItem = null;
                        }
                        this.groupOfSelectedInventorySlots.Clear();
                        done = false;
                        j = (int)item.itemInventorySize.x + q;
                        i = (int)item.itemInventorySize.y + l;                                             
                    }                    
                }
                i++;
            }
        }

        if (groupOfSelectedInventorySlots.Count == 0)
        {
            Debug.Log("Inventory is Full!");
            item.PickableItem = false;            
        }
        else
        {
            this.PutItemIconButtonIntoInventoryUI();
        }
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

            itemButtonReference.GetComponent<ItemButtonUI>().AddSlotsReferenceToButton();

            itemButtonReference.transform.position = new Vector3(centerX, centerY, 0);
            itemButtonReference.transform.parent = floatingItemButtonParent.transform;
            itemButtonReference.transform.localScale = Vector3.one;

            UIShaderManager.instance.shadeColor = UIShaderManager.ShadeColor.Default;
            UIShaderManager.instance.ApplyShade();            

            itemButtonReference = null;

            if (groupOfSelectedInventorySlots[0].storedItem != null)
            {
                this.groupOfSelectedInventorySlots[0].storedItem.gameObject.SetActive(false);
            }
            
            this.groupOfSelectedInventorySlots.Clear();
        }
    }

    public void GrabItemIconButtonFromInvenroty()
    {
        if (!this.canGrabButton)
        {
            return;
        }
        else
        {
            itemButtonReference.transform.parent = UIManager.instance.inventoryPanel.transform;
            itemButtonReference.transform.position = Input.mousePosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GrabItemIconButtonFromInvenroty();
    }
}
