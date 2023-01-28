using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlocksListController : MonoBehaviour
{
    public static BlocksListController Instance;
    public List<GameObject> blocks = new List<GameObject>();
    GameObject blocksParent;

    private void Awake()
    {
        Instance = this;
    }
    private void Start() {
        blocksParent = GameObject.Find("blocks").gameObject;
        StartCoroutine(nameof(blockScaleEffect));
    }


    public void blockChangePos(){
        foreach(GameObject block in blocks){
            BlockMoveController blockMoveController = block.GetComponent<BlockMoveController>();
            blockMoveController.setPos();

        }
    }

    IEnumerator blockScaleEffect(){
        while(true && !GameManager.Instance.isPlayerDead && !GameManager.Instance.GameWin){
            BlockScaleController[] blockScaleControllers = blocksParent.GetComponentsInChildren<BlockScaleController>();
            if(blockScaleControllers.Length > 1)
            {
                foreach (BlockScaleController bsc in blockScaleControllers)
                {
                    if (bsc != null && !GameManager.Instance.isPlayerDead)
                    {
                        bsc.scaleEffectFunc();
                    }
                    yield return new WaitForSeconds(0.2f);
                }
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
