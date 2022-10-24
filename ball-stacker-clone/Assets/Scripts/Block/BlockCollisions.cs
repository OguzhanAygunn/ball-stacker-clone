using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockCollisions : MonoBehaviour
{
    bool isCollected;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        isCollected = gameObject.CompareTag("Collected");
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Collected" 
        && other.gameObject.layer == LayerMask.NameToLayer("Block") 
        && !isCollected){
            isCollected = true;
            gameObject.tag = "Collected";
            transform.parent = player.transform;
            transform.DOLocalMove(Vector3.forward * (player.transform.childCount-1),0.25f);
            transform.DOLocalRotate(Vector3.zero,0.25f);
        }
    }
}
