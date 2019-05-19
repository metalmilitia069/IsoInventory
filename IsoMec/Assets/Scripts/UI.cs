using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject _playerReference;

    private bool _lockDrop = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(this._lockDrop)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) && UIManager.instance.itemHoldObjectTransition)
        {
            Camera _mainCam = Camera.main;
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300.0f))  //(ray, out hit, 100, movementLayer))
            {
                Debug.Log("dropar o item");
                UIManager.instance.itemHoldObjectTransition.gameObject.SetActive(true);
                UIManager.instance.itemHoldObjectTransition.transform.position = hit.point;

                UIManager.instance.itemHoldImage.sprite = null;
                UIManager.instance.itemHoldImage.gameObject.SetActive(false);

                InventoryManager.instance.RemoveFromInventory(UIManager.instance.itemHoldObjectTransition);

                UIManager.instance.itemHoldObjectTransition = null;
                InventoryManager.instance.onInventoryUpdate();
                this._lockDrop = true;
            }


        }

        //Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (Physics.Raycast(ray, out hit, 100, movementLayer))
        //    {
        //        _agent.destination = hit.point;
        //        _playerReference._canPick = false;
        //    }

        //    if (Physics.Raycast(ray, out hit, 100, interactLayer))
        //    {
        //        Debug.Log("Opa! peide nao!");
        //        _playerReference._canPick = true;
        //    }
        //}
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _playerReference.GetComponent<PlayerMove>().enabled = false;
        //Debug.Log("Mouse over UI");
        this._lockDrop = true;
    }

    public void OnPointerExit(PointerEventData eventData)//Problem Part >> TODO drop items from inventory!!!
    {
        _playerReference.GetComponent<PlayerMove>().enabled = true;

        //if(Input.GetMouseButtonDown(0) && UIManager.instance.itemHoldObjectTransition)
        //{
        //    UIManager.instance.itemHoldObjectTransition.gameObject.SetActive(true);
        //    UIManager.instance.itemHoldObjectTransition.transform.position = Input.mousePosition;
        //}
        this._lockDrop = false;
    }


}
