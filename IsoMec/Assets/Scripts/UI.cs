﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Player _playerReference;
    [SerializeField]
    public bool isDropAllowed = false;

    private void Start()
    {
        this._playerReference = FindObjectOfType<Player>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = false;
        
        this.isDropAllowed = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = true;
        
        if (InventoryManager.instance.ItemTransfer != null)
        {
            isDropAllowed = true;
        }
    }

    private void Update()
    {
        if (!isDropAllowed)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                _playerReference.GetComponent<PlayerMove>().enabled = false;

                InventoryManager.instance.RemoveFromInventory(InventoryManager.instance.ItemTransfer);
                CharacterEquipmentManager.instance.RemoveFromEquipmentList(InventoryManager.instance.ItemTransfer);
                
                InventoryManager.instance.ItemTransfer.gameObject.SetActive(true);
                float randomX = Random.Range(-_playerReference.playerDropItemRadius, _playerReference.playerDropItemRadius);
                float randomZ = Random.Range(-_playerReference.playerDropItemRadius, _playerReference.playerDropItemRadius);
                InventoryManager.instance.ItemTransfer.transform.position = new Vector3(_playerReference.transform.position.x + randomX, 5.0f, _playerReference.transform.position.z + randomZ);                

                UIManager.instance.uiSlotReference.storedItem = null;

                UIManager.instance.OnItemRemoved();
                CharacterEquipmentManager.instance.OnItemRemovedFromCharacterEquipment();                

                InventoryManager.instance.ItemTransfer = null;
                UIManager.instance.uiSlotReference = null;
                UIManager.instance.itemFloatingImageGO.hasBeenEnabled = false;
                
                this.isDropAllowed = false;

                _playerReference.GetComponent<PlayerMove>().enabled = true;
            }
        }
    }


}
