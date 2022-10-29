using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAAnimatorController : MonoBehaviour
{
    Animator animator;
    float speedValue;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        mainOperations();
    }

    void mainOperations(){
        if(GameManager.GameStart){
            if(!GameManager.isPlayerDead){
                speedValue = Mathf.MoveTowards(speedValue,1,Time.fixedDeltaTime*1.5f);
                animator.SetFloat("speed",speedValue);
            }
            else{
                speedValue = Mathf.MoveTowards(speedValue,0,Time.fixedDeltaTime*1.5f);
                animator.SetFloat("speed",speedValue);
            }
        }
    }
}
