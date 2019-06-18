using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Item : MonoBehaviour
{    
    [Header("Item Name Floating Text")]
    //[Multiline(8)]
    [SerializeField]
    public string itemName = "";
    [SerializeField]
    public TextMeshPro itemNameFloatText;
    [SerializeField]
    private float _itemNameHeight = 2f;
    [Header("Item Attributes")]
    [SerializeField]
    public int attackDamage;
    [SerializeField]
    public int attackRange;
    [SerializeField]
    public int criticalChance;
    [SerializeField]
    public string elementalDamage;
    [Header("Image Reference")]
    [SerializeField]
    public Sprite itemIcon;

    [Header("Item Configure")]
    public bool isStackable = false;
    public int itemCounter = 1;
    public Vector2 itemInventorySize;
    public Button itemUIButton;

    [Header("Item States")]
    [SerializeField]
    private bool _isPickable = false;
    [SerializeField]
    public bool wasPicked = false;
    [SerializeField]
    private int _pickableCondition = 0;


    public bool PickableItem
    {
        get { return _isPickable; }
        set { _isPickable = value; }
    }

    public ItemCategory itemCategory;
    public ItemPieceType itemPieceType;

    public enum ItemCategory
    {
        Armor,
        Weapon,
        Shield,
        Acessories,
        Booster,
        Currency,
        Health,
        Magic,
        Stamina,
        Material        
    }

    public enum ItemPieceType
    {        
        Helmet,
        Chest,
        Belt,
        Pants,
        Boots,
        Weapon,
        Shield,
        Earings,
        Necklace,
        Rings,
        None
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeItemParameters();


    }

    private void InitializeItemParameters()
    {
        if (itemCategory == ItemCategory.Currency || itemCategory == ItemCategory.Health || itemCategory == ItemCategory.Magic || itemCategory == ItemCategory.Material || itemCategory == ItemCategory.Stamina)
        {
            this.itemPieceType = ItemPieceType.None;
        }
        if (itemCategory == ItemCategory.Weapon)
        {
            this.itemPieceType = ItemPieceType.Weapon;
        }
        if (itemCategory == ItemCategory.Shield)
        {
            this.itemPieceType = ItemPieceType.Shield;
        }
        
        itemNameFloatText.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + _itemNameHeight, this.transform.position.z);
        itemNameFloatText.text = itemName;

        this.itemCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PickItemCounter();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            this._isPickable = true;            
            _pickableCondition = 0;
        }
        itemNameFloatText.gameObject.SetActive(true);
        itemNameFloatText.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseExit()
    {
        this.itemNameFloatText.gameObject.SetActive(false);
    }

    //[ContextMenu("Do Something")]
    private void PickItemCounter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pickableCondition++;
            if (_pickableCondition >= 2)
            {
                this._isPickable = false;
                _pickableCondition = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {        
        if(other.tag == "Player")
        {
            if(other.GetComponent<Player>()._canPick && this._isPickable)
            {
                //Debug.Log("Catching The Item");

                //InventoryManager.instance.AddToInventory(this);
                //UIManager.instance.AddToInventorySlotOnPickup(this);
                InventoryUIManager.instance.AddtoInventoryUI(this);
                //EventManager.instance.onItemPickup();

                //this.gameObject.SetActive(false);


                //if (InventoryManager.instance.isFull == false)
                //{
                //    this.gameObject.SetActive(false);
                //}
                //else
                //{
                //    this._isPickable = false;
                //}

            }            
        }
    }
}
