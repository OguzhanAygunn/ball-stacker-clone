using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockRotateController : MonoBehaviour
{
    [HideInInspector] public bool RotateModeActive = true;
    [SerializeField] float RotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if(RotateModeActive)
        transform.eulerAngles += Vector3.up * RotateSpeed * Time.deltaTime;
    }

    public void CollFunc()
    {
        RotateModeActive = false;
        transform.DORotate(Vector3.zero,0.5f);
    }
}
