using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIKLON : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    Transform playerPos;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Rotate();
        activeCheck();
    }

    void activeCheck()
    {
        if(playerPos.position.z - 10f > transform.position.z)
        {
            Destroy(GetComponent<Collider>());
        }
    }

    void Rotate()
    {
        transform.eulerAngles += Vector3.up * rotateSpeed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.tag = "Untagged";
            Destroy(other.GetComponent<Collider>());
            other.transform.parent = transform;
            EnemyAMovement enemyMovement = other.GetComponent<EnemyAMovement>();
            enemyMovement.ToTornado();
        }
    }
}
