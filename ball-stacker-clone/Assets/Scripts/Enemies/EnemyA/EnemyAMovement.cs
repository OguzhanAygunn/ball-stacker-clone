using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Gun").gameObject.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movementOperations();
        lookAtOperations();
    }


    void movementOperations(){
        transform.position = Vector3.MoveTowards(transform.position,targetPos.position,moveSpeed*Time.fixedDeltaTime);
    }

    void lookAtOperations(){
        transform.LookAt(targetPos.position,transform.up);
    }
}
