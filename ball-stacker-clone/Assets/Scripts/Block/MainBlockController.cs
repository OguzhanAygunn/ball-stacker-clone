using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockController : MonoBehaviour
{
    MeshRenderer myRender;
    GameObject blockParent,gun;
    UIManager uimanager;
    // Start is called before the first frame update
    void Start()
    {
        myRender                = GetComponent<MeshRenderer>();
        myRender.material.color = Color.red;
        blockParent             = GameObject.Find("blocks").gameObject;
        gun                     = GameObject.Find("Gun").gameObject;
        uimanager               = GameObject.FindObjectOfType<UIManager>();
    }

    void deathFunc(){
        GameManager.Instance.isPlayerDead = true;
        Destroy(gun);
        BlockCollisions[] blockCollisions = GetComponentsInChildren<BlockCollisions>();
        foreach(BlockCollisions bc in blockCollisions){
            bc.destroyFunc();
        }
        uimanager.gameOverEffectActive();
    }

    private void OnCollisionEnter(Collision other) {
        var otherLayer = other.gameObject.layer;
        if((otherLayer == LayerMask.NameToLayer("Obstacle") || otherLayer == LayerMask.NameToLayer("Enemy")) && !GameManager.Instance.isPlayerDead){
            deathFunc();
        }
    }
}
