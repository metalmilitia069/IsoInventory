using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public bool _canPick;
    [SerializeField]
    public float playerDropItemRadius = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(this.transform.position, playerDropItemRadius);
        Gizmos.DrawWireSphere(this.transform.position, playerDropItemRadius);
    }
}
