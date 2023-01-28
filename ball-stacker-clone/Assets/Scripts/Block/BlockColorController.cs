using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorController : MonoBehaviour
{
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<MainBlockController>())
        {
            material = GetComponent<MeshRenderer>().material;
            material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
