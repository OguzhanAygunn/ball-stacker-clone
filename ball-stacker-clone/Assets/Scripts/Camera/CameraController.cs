using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    [SerializeField] float followSpeed;
    Transform playerPos;
    [SerializeField] Vector3 offset;
    public bool ToPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followOperations();
    }

    private void followOperations(){
        if (!ToPlayer)
        {
            Vector3 targetPos = playerPos.position + offset;
            targetPos.x = transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.fixedDeltaTime);
        }

    }

    public void shakeFunc(){
        Camera.main.DOShakeRotation(0.2f,2,1).OnComplete( () => {
            transform.rotation = Quaternion.Euler(50,0,0);
        });
    }

    public void WinFunc()
    {
        offset /= 3f;
    }
}
