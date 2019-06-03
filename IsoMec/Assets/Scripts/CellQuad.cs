using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellQuad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Image cellImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cellImage.color = Color.green;
        Debug.Log("CUUUUUUUUUUUUUUUUUUUUUU");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cellImage.color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
