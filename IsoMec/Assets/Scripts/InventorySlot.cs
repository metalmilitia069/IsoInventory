using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private TextMeshProUGUI _itemName;
    [SerializeField]
    private TextMeshProUGUI _itemStatsText;
    [SerializeField]
    private TextMeshProUGUI _itemStatsTextNumbers;
    [SerializeField]
    public Image _slotIcon;
    //[SerializeField]
    //private Vector3 _mouseOffset;

    [SerializeField]
    public int _slotIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("mousing over here");
        _panel.gameObject.SetActive(true);
        this._itemName.text = InventoryManager.instance._inventoryList[this._slotIndex]._itemName;
        this._itemStatsText.text = "Attack Damage: " + "\n" + "Attack Range: " + "\n" + "Critical Chance: " + "\n" + "Elemental Damage: "; 
        this._itemStatsTextNumbers.text = InventoryManager.instance._inventoryList[this._slotIndex].attackDamage.ToString() + "\n"
            + InventoryManager.instance._inventoryList[this._slotIndex].attackRange.ToString() + "\n"
            + InventoryManager.instance._inventoryList[this._slotIndex].criticalChance.ToString() + "\n"
            + InventoryManager.instance._inventoryList[this._slotIndex].elementalDamage;

        //_panel.transform.position = new Vector3(Input.mousePosition.x + _panel.gameObject;
        //_panel.transform.position = Input.mousePosition + _mouseOffset;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouse exited the slot");
        _panel.gameObject.SetActive(false);
    }


    //{
    //    
    //}
}
