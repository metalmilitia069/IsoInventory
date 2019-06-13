using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonUI : MonoBehaviour
{
    [SerializeField]
    public Item itemReference;
    [SerializeField]
    public Image buttonImage;


    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = itemReference.itemIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
