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


    IEnumerator blockScaleEffect(){
        while(true){
            BlockScaleController[] blockScaleControllers = blocksParent.GetComponentsInChildren<BlockScaleController>();
            foreach(BlockScaleController bsc in blockScaleControllers ){
                bsc.scaleEffectFunc();
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
