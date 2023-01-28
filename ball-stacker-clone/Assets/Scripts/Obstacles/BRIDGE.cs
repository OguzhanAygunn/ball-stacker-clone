using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BRIDGE : MonoBehaviour
{
    Vector3 defaultScale;
    bool isTrigger = false;
    [SerializeField] float radius;
    [SerializeField] LayerMask targetLayer;
    // Start is called before the first frame update
    private void Awake()
    {
        defaultScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(transform.position, radius, targetLayer).Length > 0 && !isTrigger)
        {
            isTrigger = true;
            transform.DOScale(defaultScale,1f);
        }
    }
}
