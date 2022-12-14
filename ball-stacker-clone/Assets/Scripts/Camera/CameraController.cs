using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] float followSpeed;
    Transform playerPos;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        GameManager.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followOperations();
        if(Input.touchCount > 0){
            GameManager.GameStart = true;
        }
    }

    private void followOperations(){
        Vector3 targetPos = playerPos.position + offset;
        targetPos.x = transform.position.x;
        transform.position = Vector3.MoveTowards(transform.position,targetPos,followSpeed*Time.fixedDeltaTime);
    }

    public void shakeFunc(){
        Camera.main.DOShakeRotation(0.2f,2,1).OnComplete( () => {
            transform.rotation = Quaternion.Euler(43,0,0);
        });
    }
}
