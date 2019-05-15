using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [SerializeField]
    public Image _slotIcon;
    [SerializeField]
    public int _slotIndex;
    [SerializeField]
    private ItemPieceTypeSlot itemSlotType;

    public enum ItemPieceTypeSlot
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceItem()
    {
        if (this._slotIcon.sprite == null && UIManager.instance.itemHold.sprite != null)        
        {
            this._slotIcon.sprite = UIManager.instance.itemHold.sprite;
            this._slotIcon.color = Color.white;
            UIManager.instance.itemHold.sprite = null;
            UIManager.instance.itemHold.gameObject.SetActive(false);

            this._slotIndex = UIManager.instance.transitionItemIndex;
            InventoryManager.instance.RemoveFromInventory(this._slotIndex);
            UIManager.instance.inventorySlotTransition = null;
        }
    }
}
