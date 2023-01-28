using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYHANDLER : MonoBehaviour
{
    public static ENEMYHANDLER Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    public void AllEnemyDead()
    {
        EnemyACollision[] enemies = FindObjectsOfType<EnemyACollision>();
        foreach(EnemyACollision ec in enemies)
        {
            ec.deathFunc();
        }
    }
}
