using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float followSpeed;
    Transform playerPos;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followOperations();
    }

    private void followOperations(){
        transform.position = Vector3.MoveTowards(transform.position,playerPos.position + offset,followSpeed*Time.fixedDeltaTime);
    }
}
