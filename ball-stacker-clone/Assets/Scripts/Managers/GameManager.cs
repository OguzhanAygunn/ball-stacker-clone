using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static bool GameStart,isPlayerDead;
    public static void Start() {
        GameStart      = false;
        isPlayerDead   = false;
        Time.timeScale = 1.25f;
    }
}
