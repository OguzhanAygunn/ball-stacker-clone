using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockScaleController : MonoBehaviour
{
    Vector3 upScale,defaultScale;
    void Start()
    {
        defaultScale = transform.localScale;
        upScale = defaultScale * 1.25f;
    }

    public void scaleEffectFunc(){
        transform.DOScale(upScale,0.2f).OnComplete( () => {
            transform.DOScale(defaultScale,0.2f);
        });
    }

}
