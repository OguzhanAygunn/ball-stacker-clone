using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] float spawnTime;
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPosS;
    [SerializeField] Vector3 offset;
    Transform playerPos;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(enemySpawnFunc));
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    private void FixedUpdate() {
        movementOperations();
    }

    void movementOperations(){
        pos = playerPos.position + offset;
        pos.x = transform.position.x;
        transform.position = pos;
    }

    IEnumerator enemySpawnFunc(){
        while(true){
            if(true){
                int enemyValue = Random.Range(0,  enemies.Length);
                int posValue   = Random.Range(0,spawnPosS.Length);
                Instantiate(enemies[enemyValue],spawnPosS[posValue].position,Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
