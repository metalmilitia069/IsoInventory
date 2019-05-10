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

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))//(ray, out hit, 100, movementLayer)) //(ray, out hit, 100))
            {
                _agent.destination = hit.point;
                //Debug.Log(hit.distance);
            }
            else if(Physics.Raycast(ray, out hit, 100, interactLayer))
            {
                Debug.Log("Opa! peide nao!");
            }

        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.cyan);
        
    }
}
