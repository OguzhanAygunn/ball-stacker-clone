using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockController : MonoBehaviour
{
    MeshRenderer myRender;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<MeshRenderer>();
        myRender.material.color = Color.red;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Obstacle")){
            
        }
    }
}
