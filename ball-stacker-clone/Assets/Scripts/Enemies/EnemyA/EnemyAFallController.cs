using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAFallController : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;
    EnemyACollision enemyACollision;
    float fallTime = .5f;
    EnemyAMovement enemyAMovement;
    // Start is called before the first frame update
    void Start()
    {
        enemyACollision = GetComponent<EnemyACollision>();
        enemyAMovement  = GetComponent<EnemyAMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rayOperations();
    }

    void rayOperations(){
        RaycastHit hit;
        Vector3 rayScale = new Vector3(0,-10f,0);
        if(!Physics.Raycast(transform.position,rayScale,out hit,Mathf.Infinity,groundLayer)){
            Debug.Log("213123");
            fallTime = Mathf.MoveTowards(fallTime,0,Time.fixedDeltaTime);
            if(fallTime == 0){
                enemyACollision.deathFunc();
                enemyAMovement.enabled = false;
                this.enabled = false;
            }
        }
    }
}
