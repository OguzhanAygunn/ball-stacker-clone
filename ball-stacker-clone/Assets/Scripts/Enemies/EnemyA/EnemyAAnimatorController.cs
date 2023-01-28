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
        animator.SetFloat("speed", 1);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //mainOperations();
    }

    void mainOperations(){
        if(GameManager.Instance.GameStart){
            if(!GameManager.Instance.isPlayerDead){
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
