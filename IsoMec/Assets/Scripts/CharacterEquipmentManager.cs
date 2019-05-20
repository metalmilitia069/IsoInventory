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

    
}
