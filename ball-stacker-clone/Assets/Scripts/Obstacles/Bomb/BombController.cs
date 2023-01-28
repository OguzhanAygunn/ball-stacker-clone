using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] LayerMask BlockLayer;
    bool isTrigger;
    Transform targetPos;
    Rigidbody rigidbody;
    [SerializeField] float speed,radius;
    [SerializeField] GameObject[] destroyEffects;
    CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rayOperations();
        movementOperations();
    }

    void rayOperations(){
        Collider[] objs = Physics.OverlapSphere(transform.position,radius,BlockLayer);
        if(!isTrigger){
            foreach(Collider obj in objs){
                GameObject obj_ = obj.gameObject;
                if(obj_.tag == "Collected"){
                    targetPos = obj_.transform;
                    isTrigger = true;
                    rigidbody.AddTorque(Vector3.one * 360);
                }
            }
        }
    }

    void movementOperations(){
        if(targetPos){
            Vector3 targetVec = targetPos.position;
            targetVec.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position,targetVec,speed*Time.fixedDeltaTime);
        }
    }


    private void collFunction(GameObject collObj){
        Destroy(gameObject);
        int random = Random.Range(0, destroyEffects.Length);
        Instantiate(destroyEffects[random],transform.position,Quaternion.identity);
        cameraController.shakeFunc();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Block")){
            if(other.gameObject.tag == "Collected")
            {
                collFunction(other.gameObject);
            }
        }
    }


}
