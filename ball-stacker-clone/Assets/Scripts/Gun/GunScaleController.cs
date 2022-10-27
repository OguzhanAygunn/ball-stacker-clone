using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunScaleController : MonoBehaviour
{
    Vector3 upScale,defaultScale;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void scaleUpFunc(float time){
        transform.DOScale(upScale,time).OnComplete( () => {
            transform.DOScale(defaultScale,time);
        });
    }

    public void scaleUpdate(){
        defaultScale = transform.localScale;
        upScale      = defaultScale * 1.3f;
    }
}
