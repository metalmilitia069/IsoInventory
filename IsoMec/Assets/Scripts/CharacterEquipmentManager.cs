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

    public delegate void OnCharacterEquipmentChange();
    public OnCharacterEquipmentChange onCharacterEquipmentChange;

    [SerializeField]
    public List<Item> characterEquipmentList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToCharacterEquipment(Item item)
    {
        this.characterEquipmentList.Add(item);
        InventoryManager.instance.onInventoryChange();
    }

    //public void RemoveFromCharacterEquipment(int index)
    //{
    //    this.characterEquipmentList.RemoveAt(index);
    //    //this.characterEquipmentList.Remove()
    //}

    public void RemoveFromCharacterEquipment(Item item)
    {
        //this.characterEquipmentList.RemoveAt(index);
        this.characterEquipmentList.Remove(item);

        InventoryManager.instance.onInventoryChange();
    }
}
