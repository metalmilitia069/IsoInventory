using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{

    private NavMeshAgent _agent;
    private Camera _mainCam;

    [SerializeField]
    private LayerMask movementLayer;
    [SerializeField]
    private LayerMask interactLayer;


    [SerializeField]
    private Player _playerReference;


        

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerReference = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100, movementLayer))            
            {
                _agent.destination = hit.point;
                _playerReference._canPick = false;                
            }

            if(Physics.Raycast(ray, out hit, 100, interactLayer))            
            {
                Debug.Log("Opa! peide nao!");
                _playerReference._canPick = true;                
            }            
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);        
    }
}
