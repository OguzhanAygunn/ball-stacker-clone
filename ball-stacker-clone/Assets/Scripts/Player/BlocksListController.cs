using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksListController : MonoBehaviour
{
    public static List<GameObject> blocks = new List<GameObject>();
    private void Start() {
        blocks.Add(transform.GetChild(0).gameObject);
    }
}
