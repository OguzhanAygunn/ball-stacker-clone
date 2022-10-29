using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlocksListController : MonoBehaviour
{
    public static List<GameObject> blocks = new List<GameObject>();
    GameObject blocksParent;
    private void Start() {
        blocksParent = GameObject.Find("blocks").gameObject;
        StartCoroutine(nameof(blockScaleEffect));
    }


    public static void blockChangePos(){
        foreach(GameObject block in blocks){
            BlockMoveController blockMoveController = block.GetComponent<BlockMoveController>();
            blockMoveController.setPos();

        }
    }

    IEnumerator blockScaleEffect(){
        while(true && !GameManager.isPlayerDead){
            BlockScaleController[] blockScaleControllers = blocksParent.GetComponentsInChildren<BlockScaleController>();
            foreach(BlockScaleController bsc in blockScaleControllers){
                if(bsc != null && !GameManager.isPlayerDead){
                    bsc.scaleEffectFunc();
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
