using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    float rotValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rotateOperations();
    }

    void rotateOperations(){
        rotValue = transform.position.x * 5f;
        transform.eulerAngles = new Vector3(0,rotValue,0);
    }
}
