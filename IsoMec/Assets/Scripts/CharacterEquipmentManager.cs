using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipmentManager : MonoBehaviour
{
    #region Singleton
    public static CharacterEquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    public List<CharacterSlot> characterSlotsList;
    [SerializeField]
    public List<Item> characterEquipmentList;

    private void Start()
    {
        characterSlotsList.AddRange(FindObjectsOfType<CharacterSlot>());
    }

    public void AddToCharacterEquipmentList(Item item)
    {
        characterEquipmentList.Add(item);
    }

    public void RemoveFromEquipmentList(Item item)
    {
        this.characterEquipmentList.Remove(item);
    }

    public void OnItemRemovedFromCharacterEquipment()
    {
        for (int i = 0; i < characterSlotsList.Count; i++)
        {
            if (characterSlotsList[i].storedItem == null)
            {                 
                characterSlotsList[i].itemName = null;
                characterSlotsList[i].itemNameFloatText = null;
                characterSlotsList[i].attackDamage = 0;
                characterSlotsList[i].criticalChance = 0;
                characterSlotsList[i].elementalDamage = null;
                characterSlotsList[i].itemIcon.sprite = null;
                characterSlotsList[i].itemIcon.color = new Color(161.0f / 255, 87.0f / 255, 87.0f / 255, 255.0f / 255);
                characterSlotsList[i].itemCategory = "";
                characterSlotsList[i].itemPieceType = "";
            }
            
        }
    }
}
