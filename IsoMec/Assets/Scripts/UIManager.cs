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
    public GameObject inventoryPanel;

    [SerializeField]
    public ItemFloatingImage itemFloatingImageGO;

    [SerializeField]
    public GameObject itemInformationPanel;
    [SerializeField]
    public TextMeshProUGUI itemNameText;
    [SerializeField]
    public TextMeshProUGUI itemStatsText;
    [SerializeField]
    public TextMeshProUGUI itemStatsNumbersText;


    [SerializeField]
    public UISlotsBase uiSlotReference;


    [SerializeField]
    public GameObject inventorySpace;

    //[Header("INVENTORY UI")]
    //public List<InventorySlot> listOfinventorySlots;

    private void Start()
    {
        //listOfinventorySlots.AddRange(FindObjectsOfType<InventorySlot>());
        
    }




    private void Update()
    {
        OpenInventoryPanel();
    }

    private void OpenInventoryPanel()
    {
        if (Input.GetButtonDown("InventoryButton"))
        {
            if (!this.inventoryPanel.activeSelf)
            {
                this.inventoryPanel.gameObject.SetActive(true);
            }
            else
            {
                this.inventoryPanel.gameObject.SetActive(false);
            }
        }
    }
        
    
}
