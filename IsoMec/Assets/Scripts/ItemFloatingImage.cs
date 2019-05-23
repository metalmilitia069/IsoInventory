using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloatingImage : MonoBehaviour
{
    private void Update()
    {
        if (!this.enabled)
        {
            return;
        }
        else
        {
            this.transform.position = Input.mousePosition;
        }
    }
}
