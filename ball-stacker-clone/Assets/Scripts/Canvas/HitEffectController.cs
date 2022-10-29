using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HitEffectController : MonoBehaviour
{
    [SerializeField] Image[] images;
    Color defaultColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = images[0].color;
    }

    public void hitEffectActive(){
        foreach(Image image in images){
            image.DOColor(Color.red,0.333f).OnComplete( () => {
                image.DOColor(defaultColor,0.333f);
            });
        }
    }
}
