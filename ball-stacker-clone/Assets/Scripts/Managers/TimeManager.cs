using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public float timeScale;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Time.timeScale = timeScale;
    }
}
