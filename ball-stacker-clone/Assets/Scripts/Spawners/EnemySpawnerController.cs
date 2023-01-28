using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPosS;
    [SerializeField] Vector3 offset;
    [SerializeField] LayerMask GroundLayer;
    Transform playerPos;
    Vector3 pos;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(enemySpawnFunc));
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void FixedUpdate() {
        movementOperations();
        RayOP();
    }

    void movementOperations(){
        pos = playerPos.position + offset;
        pos.x = transform.position.x;
        transform.position = pos;
    }

    void RayOP()
    {
        if (Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity, GroundLayer))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    IEnumerator enemySpawnFunc(){
        while(!GameManager.Instance.GameWin){
            if(!GameManager.Instance.isPlayerDead && GameManager.Instance.GameStart && onGround){
                int enemyValue = Random.Range(0,  enemies.Length);
                int posValue   = Random.Range(0,spawnPosS.Length);
                Instantiate(enemies[enemyValue],spawnPosS[posValue].position,Quaternion.identity, transform.parent);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
