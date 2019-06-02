﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlotsBase : MonoBehaviour
{
    [Header("Item Name Floating Text")]
    //[Multiline(8)]
    [SerializeField]
    public string itemName = "";
    [SerializeField]
    public TextMeshPro itemNameFloatText;
    //[SerializeField]
    //private float itemNameHeight = 2f;
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
    public Image itemIcon;
    [SerializeField]
    public string itemCategory = "";
    [SerializeField]
    public string itemPieceType = "";

    [Header("Information Panels")]
    //[SerializeField]
    //private GameObject _itemInformationPanel;
    [SerializeField]
    public TextMeshProUGUI itemNameText;
    [SerializeField]
    public TextMeshProUGUI itemStatsText;
    [SerializeField]
    public TextMeshProUGUI itemStatsNumbersText;
    [SerializeField]
    public TextMeshProUGUI itemQuantityText;
    [Header("Stored Item")]
    [SerializeField]
    public Item storedItem;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.onItemPickup += OnItemPickup;
        //EventManager.instance.onItemRemoved += OnItemRemoved;
        SetInformationPanelReference();
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnItemPickup()
    {
        if (this.storedItem != null)
        {
            this.itemName = this.storedItem.itemName;
            this.itemNameFloatText = this.storedItem.itemNameFloatText;
            this.attackDamage = this.storedItem.attackDamage;
            this.criticalChance = this.storedItem.criticalChance;
            this.elementalDamage = this.storedItem.elementalDamage;
            this.itemIcon.sprite = this.storedItem.itemIcon;
            this.itemIcon.color = Color.white;
            this.itemCategory = this.storedItem.itemCategory.ToString();
            this.itemPieceType = this.storedItem.itemPieceType.ToString();

            if (this.storedItem.isStackable)
            {
                this.itemQuantityText.gameObject.SetActive(true);
                this.itemQuantityText.text = this.storedItem.itemCounter.ToString();
            }
        }
    }    

    private void SetInformationPanelReference()
    {        
        this.itemNameText = UIManager.instance.itemNameText;
        this.itemStatsText = UIManager.instance.itemStatsText;
        this.itemStatsNumbersText = UIManager.instance.itemStatsNumbersText;
    }

    public void ShowItemStats()
    {
        UIManager.instance.itemInformationPanel.gameObject.SetActive(true);
        this.itemNameText.text = this.itemName;
        this.itemNameText.color = this.itemNameFloatText.color;
        this.itemStatsText.text = "Attack Damage: \n" + "Attack Range: \n" + "Critical Chance: \n" + "Elemental Damage: ";
        this.itemStatsNumbersText.text = this.attackDamage.ToString() + "\n" + this.attackRange.ToString() + "\n" + this.criticalChance.ToString() + "\n" + this.elementalDamage;
    }

    public void HideItemStats()
    {
        UIManager.instance.itemInformationPanel.gameObject.SetActive(false);
        this.itemNameText.text = null;
        this.itemStatsText.text = null;
        this.itemStatsNumbersText.text = null; 
    }

    public void TransferItem()
    {
        
    }

    
}
