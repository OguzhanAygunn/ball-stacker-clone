using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Touch touch;
    [SerializeField] float sensibility;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        movementOperations();
    }

    void movementOperations(){
        if(Input.touchCount > 0 && !GameManager.isPlayerDead){
            touch = Input.GetTouch(0);
            Vector3 pos = Vector3.zero;
            pos.x += touch.deltaPosition.x / sensibility * Time.fixedDeltaTime;
            transform.position += pos;
            transform.position += Vector3.forward / 10f;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,-3,3),transform.position.y,transform.position.z);
    }
    }
}
