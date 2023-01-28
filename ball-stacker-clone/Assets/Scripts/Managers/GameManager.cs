using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool GameStart,isPlayerDead,GameWin;

    private void Awake()
    {
        GameStart = false;
        isPlayerDead = false;
        GameWin = false;
        Instance = this;
    }
    public void Start() {
        Time.timeScale = 1.25f;
    }
}
