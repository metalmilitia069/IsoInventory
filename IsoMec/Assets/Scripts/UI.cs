using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _playerReference;

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
        _playerReference.GetComponent<PlayerMove>().enabled = false;
        Debug.Log("Mouse over UI");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = true;
    }
}
