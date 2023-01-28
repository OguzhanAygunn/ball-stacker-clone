using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool spawnTheCorners;
    public GameObject Corner;
    public Color CornerColors;
    private void Awake()
    {
        if (spawnTheCorners)
        {
            CornernSpawner();
        }
    }

    void CornernSpawner()
    {
        GameObject cornerA = Instantiate(Corner, transform.position, Quaternion.Euler(Vector3.right*90));
        Vector3 cornerApos = cornerA.transform.position;
        cornerApos.x -= transform.localScale.x / 2;
        cornerApos.y += transform.localScale.y / 2;
        cornerA.transform.position = cornerApos;

        Vector3 cornerAScale = transform.localScale;
        cornerAScale.x = 0.8f;
        cornerAScale.z = 0.8f;
        cornerAScale.y = transform.localScale.z / 2;
        cornerA.transform.localScale = cornerAScale;

        cornerA.GetComponent<MeshRenderer>().material.color = CornerColors;


        GameObject cornerB = Instantiate(Corner, transform.position, Quaternion.Euler(Vector3.right * 90));
        Vector3 cornerBpos = cornerB.transform.position;
        cornerBpos.x += transform.localScale.x / 2;
        cornerBpos.y += transform.localScale.y / 2;
        cornerB.transform.position = cornerBpos;

        Vector3 cornerBScale = transform.localScale;
        cornerBScale.x = 0.8f;
        cornerBScale.z = 0.8f;
        cornerBScale.y = transform.localScale.z / 2;
        cornerB.transform.localScale = cornerBScale;

        cornerB.GetComponent<MeshRenderer>().material.color = CornerColors;
    }
}
