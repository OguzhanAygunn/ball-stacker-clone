using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSawController : MonoBehaviour
{
    [SerializeField] float rotSpeed,moveSpeed;
    Vector3 firstPos,targetPos;
    bool toTargetPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
        targetPos = firstPos;
        targetPos.x = Mathf.Abs(firstPos.x);
    }

    // Update is called once per frame
    void Update()
    {
        rotateOperations();
        movementOperations();
    }

    void rotateOperations(){
        transform.Rotate(0,0,rotSpeed*Time.deltaTime);
    }

    void movementOperations(){
        if(toTargetPos){
            transform.position = Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
            if(transform.position == targetPos){
                toTargetPos = false;
            }
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position,firstPos,moveSpeed*Time.deltaTime);
            if(transform.position == firstPos){
                toTargetPos = true;
            }
        }
    }
}
