using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletAController : MonoBehaviour
{
    Material material;
    Vector3 targetScale;
    [SerializeField] GameObject destroyEffect;
    bool isColl;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        targetScale = transform.localScale * 1.3f;
        Destroy(gameObject, 2.6f);
    }

    void collFunc(){
        isColl = true;
        material.DOColor(Color.red,0.5f);
        transform.DOScale(targetScale,0.5f).OnComplete( () => {
            Instantiate(destroyEffect,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        });
    }

    private void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        if(tag == "Enemy"){
            collFunc();
        }
    }
}
