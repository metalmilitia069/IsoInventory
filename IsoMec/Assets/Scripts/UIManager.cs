using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    #region Singleton

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    [SerializeField]
    private GameObject _inventoryPanel;

    [SerializeField]
    public GameObject itemInformationPanel;

    public List<InventorySlot> listOfinventorySlots;

    private void Update()
    {
        OpenInventoryPanel();
        //_inventoryPanel == null ? _inventoryPanel.gameObject.SetActive(true) : _inventoryPanel.gameObject.SetActive(false);
    }

    private void OpenInventoryPanel()
    {
        if (Input.GetButtonDown("InventoryButton"))
        {
            if (!this._inventoryPanel.activeSelf)
            {
                this._inventoryPanel.gameObject.SetActive(true);
            }
            else
            {
                this._inventoryPanel.gameObject.SetActive(false);
            }
        }
    }
        
    private void Start()
    {
        listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());

        EventManager.instance.onAddToInventory += AddToInventorySlot;
    }

    public void AddToInventorySlot()
    {
        for (int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            if(listOfinventorySlots[i].storedItem == null)
            {
                listOfinventorySlots[i].storedItem = InventoryManager.instance.inventoryList[i];
            }
        }
        
    }
}
