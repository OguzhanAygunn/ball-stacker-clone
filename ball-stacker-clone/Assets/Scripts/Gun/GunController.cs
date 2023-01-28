using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float scaleSpeed,ballSpeed;
    public int numberValue;
    Vector3 upScale,defaultScale;
    bool scaleUp,fire;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        upScale      = defaultScale * 1.25f;
        StartCoroutine(shootFunction());
    }

    // Update is called once per frame
    void Update()
    {
        scaleOperations();
    }

    void scaleOperations(){
        if(scaleUp){
            transform.localScale = Vector3.MoveTowards(transform.localScale,upScale,scaleSpeed*Time.deltaTime);
            if(transform.localScale == upScale)
            scaleUp = !scaleUp;
        }
        else{
            transform.localScale = Vector3.MoveTowards(transform.localScale,defaultScale,scaleSpeed*Time.deltaTime);
        }
    }

    int calculation(){
        int bulletCount = 0;
        foreach(GameObject block in BlocksListController.Instance.blocks){
            if (block != null)
            {
                BlockValue blockValue = block.GetComponent<BlockValue>();
                int numberValue = blockValue.numberValue;
                switch (blockValue.typeValue)
                {
                    case BlockValue.TypeValue.plus:
                        bulletCount += numberValue;
                        break;
                    case BlockValue.TypeValue.multipler:
                        bulletCount *= numberValue;
                        break;
                    case BlockValue.TypeValue.division:
                        bulletCount /= numberValue;
                        break;
                }
            }
        }
        Debug.Log(bulletCount.ToString());
        if(bulletCount == 0)
            bulletCount = 1;
        return bulletCount;
    }
    IEnumerator shootFunction(){
        fire = true;
        while(true){
            if(!GameManager.Instance.isPlayerDead && GameManager.Instance.GameStart && !GameManager.Instance.GameWin)
            {
                GameObject bullet_ = Instantiate(bullet, transform.position, transform.rotation);
                Rigidbody bulletRigid = bullet_.GetComponent<Rigidbody>();
                bulletRigid.AddForce(transform.TransformDirection(Vector3.back) * ballSpeed);
                scaleUp = true;
                yield return new WaitForSeconds(1f / calculation());
            }
            else
            {
                yield return new WaitForSeconds(1f / calculation());
            }
        }
    }
}
