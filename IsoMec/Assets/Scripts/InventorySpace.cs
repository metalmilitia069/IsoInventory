using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour
{
    [SerializeField]
    public GridLayoutGroup gridLayout;
    
    [SerializeField]
    public int numberOfCells;

    [SerializeField]
    public GameObject inventorySlotCellPrefb;

    [SerializeField]
    public int inventoryColumns;

    //[SerializeField]
    //public Text cellName;

    //int j = 0;


    // Start is called before the first frame update
    void Start()
    {
        gridLayout.cellSize = InventoryManager.instance.cellSize;
        numberOfCells = InventoryManager.instance.inventoryCapacity;
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        inventoryColumns = InventoryManager.instance.numberOfColumns;
        gridLayout.constraintCount = inventoryColumns;



        for (int i = 0; i < numberOfCells / inventoryColumns; i++)
        {
            for (int j = 0; j < inventoryColumns; j++)
            {
                GameObject cellInstance;
                cellInstance = Instantiate(inventorySlotCellPrefb, this.transform.position, Quaternion.identity);
                cellInstance.transform.parent = this.transform;
                cellInstance.name = $"Slot[{i},{j}]";
                cellInstance.transform.localScale = Vector3.one;
                cellInstance.GetComponentInChildren<Text>().text = cellInstance.name;
                cellInstance.GetComponent<InventorySlot>().cellSlotCoordinates = new Vector2(i, j);
            }

            
            //j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
