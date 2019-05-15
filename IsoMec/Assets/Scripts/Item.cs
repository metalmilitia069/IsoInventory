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
    public string _itemName = "";
    [SerializeField]
    public TextMeshPro _itemNameFloatText;
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

    [SerializeField]
    public Sprite itemIconPlaceHolder;
    //[SerializeField]
    //private Player _playerReference;



    [SerializeField]
    private bool _isPickable = false;
    [SerializeField]
    private bool _wasPicked = false;
    
    public bool PickableItem
    {
        get { return _isPickable; }
        set { _isPickable = value; }
        
    }

    [SerializeField]
    private int _pickableCondition = 0;


    // Start is called before the first frame update
    void Start()
    {
        //_playerReference = FindObjectOfType<Player>();
        _itemNameFloatText.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + _itemNameHeight, this.transform.position.z);
        _itemNameFloatText.text = _itemName;
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
        _itemNameFloatText.gameObject.SetActive(true);
        _itemNameFloatText.transform.LookAt(Camera.main.transform);
    }

    private void OnMouseExit()
    {
        _itemNameFloatText.gameObject.SetActive(false);
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
                Debug.Log("Catching The Item");
                
                InventoryManager.instance.AddToInventory(this);

                if(InventoryManager.instance.isfull == false)
                {
                    this.gameObject.SetActive(false);
                    //Destroy(this.gameObject);
                }
                else
                {
                    this._isPickable = false;
                }

            }            
        }
    }
}
