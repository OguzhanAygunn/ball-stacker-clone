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
    }

    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if(tag == "Bullet" && animator.enabled){
            collFunc();
        }
    }
}
