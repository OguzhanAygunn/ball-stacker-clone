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
    BlockMoveController blockMoveController;
    BlockRotateController blockRotateController;
    Color myColor;
    CameraController cameraController;
    UIManager uimanager;
    // Start is called before the first frame update

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        isCollected = gameObject.CompareTag("Collected");
    }
    void Start()
    {
        blockScaleController = GetComponent<BlockScaleController>();
        parentObj = GameObject.Find("blocks").gameObject;
        myColor = GetComponent<MeshRenderer>().material.color;
        blockMoveController = GetComponent<BlockMoveController>();
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();
        uimanager = GameObject.FindObjectOfType<UIManager>();
        if (isCollected)
            BlocksListController.Instance.blocks.Add(this.gameObject);
    }

    public void collFunc(){
        BlocksListController.Instance.blocks.Add(this.gameObject);
        isCollected = true;
        gameObject.tag = "Collected";
        transform.parent = parentObj.transform;
        transform.DOLocalRotate(Vector3.zero,0.25f);
        blockMoveController.setPos();
    }

    public void destroyFunc(){
        BlocksListController.Instance.blocks.Remove(gameObject);
        Destroy(this.gameObject);
        GameObject effect = Instantiate(destroyEffect,transform.position,Quaternion.identity);
        effect.GetComponent<ParticleSystem>().startColor = myColor;
        BlocksListController.Instance.blockChangePos();
        cameraController.shakeFunc();
        uimanager.hitEffectActive();
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
