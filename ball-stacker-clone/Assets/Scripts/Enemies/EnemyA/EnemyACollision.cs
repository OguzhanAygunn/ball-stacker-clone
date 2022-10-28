using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyACollision : MonoBehaviour
{
    Animator animator;
    EnemyAMovement enemyAMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyAMovement = GetComponent<EnemyAMovement>();
    }

    void collFunc(){
        animator.enabled = false;
        enemyAMovement.enabled = false;
        transform.DOScale(Vector3.zero,0.66f).SetDelay(1.5f).OnComplete( () => {
            Destroy(this.gameObject);
        });
    }

    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if((tag == "Bullet" 
        || tag == "Wall" 
        || other.gameObject.layer == LayerMask.NameToLayer("Obstacle")) 
        && animator.enabled){
            collFunc();
        }
    }
}
