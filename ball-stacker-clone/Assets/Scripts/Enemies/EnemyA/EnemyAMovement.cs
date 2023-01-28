using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Transform targetPos;
    Vector3 targetVec;
    bool toTornado;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Gun").gameObject.transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!GameManager.Instance.isPlayerDead){
            movementOperations();
            lookAtOperations();
        }
    }


    void movementOperations(){
        if(!toTornado)
        transform.position = Vector3.MoveTowards(transform.position,targetPos.position,moveSpeed*Time.fixedDeltaTime);
    }

    void lookAtOperations(){
        if (!toTornado)
        {
            transform.LookAt(targetPos.position, Vector3.up);
            Vector3 rot = transform.eulerAngles;
            rot.x = 0;
            rot.z = 0;
            transform.eulerAngles = rot;
        }
    }

    public void ToTornado()
    {
        toTornado = true;
        transform.DOLocalMove(Vector3.zero,1f).OnComplete( () => {
            Destroy(this.gameObject);
        });
        transform.DOScale(Vector3.zero,1f).SetDelay(0.3f);
    }
}
