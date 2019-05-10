using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraArm;
    [SerializeField]
    private Camera cameraFollow;
    [SerializeField]
    private Player player;


    private void Awake()
    {
        cameraFollow = this.GetComponent<Camera>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow.transform.position = player.transform.position - cameraArm;
        cameraFollow.transform.LookAt(player.transform.position, Vector3.up);
    }
}
