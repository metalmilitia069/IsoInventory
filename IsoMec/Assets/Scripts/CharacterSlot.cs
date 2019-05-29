using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSlot : UISlotsBase, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.storedItem != null)
        {
            base.ShowItemStats();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        base.HideItemStats();
    }

    [Header("Slot Type: ")]
    public SlotCategory slotCategory;
    public SlotItemPieceType slotItemPieceType;

    public enum SlotCategory
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

    public enum SlotItemPieceType
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
}
