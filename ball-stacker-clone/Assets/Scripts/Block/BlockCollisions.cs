using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockCollisions : MonoBehaviour
{
    bool isCollected;
    GameObject player;

    public delegate void voidfuncs();

    voidfuncs collisionFuncs;
    BlockScaleController blockScaleController;
    GameObject parentObj;
    [SerializeField] GameObject destroyEffect;
    Color myColor;
    // Start is called before the first frame update

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        isCollected = gameObject.CompareTag("Collected");
        if(isCollected)
        BlocksListController.blocks.Add(this.gameObject);
    }
    void Start()
    {
        blockScaleController = GetComponent<BlockScaleController>();
        parentObj = GameObject.Find("blocks").gameObject;
        myColor = GetComponent<MeshRenderer>().material.color;
    }

    private void collFunc(){
        float zPos = 1f;
        zPos = (BlocksListController.blocks.Count) * 1.25f;
        BlocksListController.blocks.Add(this.gameObject);
        isCollected = true;
        gameObject.tag = "Collected";
        transform.parent = parentObj.transform;
        transform.DOLocalMove(Vector3.forward * zPos,0.25f);
        transform.DOLocalRotate(Vector3.zero,0.25f);
    }

    private void destroyFunc(){
        BlocksListController.blocks.Remove(gameObject);
        Destroy(this.gameObject);
        GameObject effect = Instantiate(destroyEffect,transform.position,Quaternion.identity);
        effect.GetComponent<ParticleSystem>().startColor = myColor;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Collected" 
        && other.gameObject.layer == LayerMask.NameToLayer("Block") 
        && !isCollected){
            collFunc();
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Obstacle") 
        && GetComponent<MainBlockController>() == null){
            destroyFunc();
        }
    }
}
