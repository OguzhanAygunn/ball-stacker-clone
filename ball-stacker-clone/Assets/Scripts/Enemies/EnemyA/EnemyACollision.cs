using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyACollision : MonoBehaviour
{
    Animator animator;
    EnemyAMovement enemyAMovement;
    Collider collider;
    Rigidbody rigidbody;
    [SerializeField] GameObject collWallEffect;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyAMovement = GetComponent<EnemyAMovement>();
        collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void deathFunc(){
        if (collider)
        {
            gameObject.layer = 0;
            animator.enabled = false;
            enemyAMovement.enabled = false;
            collider.enabled = false;
            transform.DOScale(Vector3.zero, 0.66f).SetDelay(1.5f).OnComplete(() => {
                Destroy(this.gameObject);
            });
        }
    }



    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if((tag == "Bullet" 
        || other.gameObject.layer == LayerMask.NameToLayer("Obstacle")) 
        && animator.enabled){
            deathFunc();
        }
        else if(tag == "Wall")
        {
            deathFunc();
            Vector3 collPoint = other.contacts[0].point;
            Instantiate(collWallEffect, collPoint, Quaternion.identity);
        }
    }
}
