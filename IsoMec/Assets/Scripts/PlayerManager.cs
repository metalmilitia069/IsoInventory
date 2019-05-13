using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    private static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    private List<Player> _playersList;

    // Start is called before the first frame update
    void Start()
    {
        _playersList.Add(FindObjectOfType<Player>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
