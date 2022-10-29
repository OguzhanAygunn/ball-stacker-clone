using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMoveController : MonoBehaviour
{
    bool first;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setPos(){
        StartCoroutine(nameof(setPosFunc));
    }

    IEnumerator setPosFunc(){
        if(first)
        yield return new WaitForSeconds(0.4f);
        else
        first = true;

        float zPos = 1f;
        zPos = (BlocksListController.blocks.IndexOf(gameObject)) * 1.25f;
        transform.DOLocalMove(Vector3.forward * zPos,0.25f);
    }
}
