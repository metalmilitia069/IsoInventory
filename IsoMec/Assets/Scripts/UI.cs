using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Player _playerReference;

    private void Start()
    {
        this._playerReference = FindObjectOfType<Player>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = false;        
        //this._lockDrop = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = true;
        //this._lockDrop = false;
    }
}
